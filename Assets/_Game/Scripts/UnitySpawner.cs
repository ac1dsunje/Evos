using System;
using System.Threading;
using _Game.Scripts.Configs;
using _Game.Scripts.ECS;
using Cysharp.Threading.Tasks;
using FFS.Libraries.StaticEcs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer;
using Random = UnityEngine.Random;

namespace _Game.Scripts
{
public class UnitySpawner : MonoBehaviour
{
    
    [SerializeField] private int _maxCreatures = 500;
    [SerializeField] private float _interval = 1f;

    [SerializeField] private Transform _container;
    
    [Inject] private CreatureSpawner _spawner;
    
    private CancellationTokenSource _cts;
    private int _count;
    
    private const string PlayerConfig = "Creature_player_config";
    private AsyncOperationHandle<CreatureConfig> _playerHandle;
    private CreatureConfig _playerConfig;
    
    private const string EnemyConfig = "Creature_mossGolem_config";
    private AsyncOperationHandle<CreatureConfig> _enemyHandle;
    private CreatureConfig _enemyConfig;
    
    private const string CreaturePrefabAddress = "Creature_prefab";
    private AsyncOperationHandle<GameObject> _prefabHandle;
    private GameObject _prefab;
    
    public event Action<EntityGID> OnPlayerSpawned;
    
    private async UniTaskVoid Start()
    {
        _cts = new CancellationTokenSource();
        
        await LoadPrefabAsync(_cts.Token);
        await LoadPlayerConfigAsync(_cts.Token);
        await LoadEnemyConfigAsync(_cts.Token);
            
        SpawnPlayer(_playerConfig);
            
        SpawnEnemiesLoop().Forget();
    }
    
    private async UniTask LoadPrefabAsync(CancellationToken token)
    {
        _prefabHandle = Addressables.LoadAssetAsync<GameObject>(CreaturePrefabAddress);
        _prefab = await _prefabHandle.ToUniTask(cancellationToken: token);
    }

    private async UniTask LoadPlayerConfigAsync(CancellationToken token)
    {
        _playerHandle = Addressables.LoadAssetAsync<CreatureConfig>(PlayerConfig);
        _playerConfig = await _playerHandle.ToUniTask(cancellationToken: token);
    }
    
    private async UniTask LoadEnemyConfigAsync(CancellationToken token)
    {
        _enemyHandle = Addressables.LoadAssetAsync<CreatureConfig>(EnemyConfig);
        _enemyConfig = await _enemyHandle.ToUniTask(cancellationToken: token);
    }
    
    private void SpawnPlayer(CreatureConfig config)
    {
        var gid = SpawnCreature(config, Vector2.zero);
        OnPlayerSpawned?.Invoke(gid);
    }

    private void SpawnEnemy(CreatureConfig config)
    {
        SpawnCreature(config, new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)));
    }

    private EntityGID SpawnCreature(CreatureConfig config, Vector2 spawnPoint)
    {
        var view = Instantiate(_prefab, _container).GetComponent<EntityView>();
        var body = view.Body;
        var render = view.Renderer;
        
        render.sprite = config.Sprite;
        view.transform.position = spawnPoint;
        
        var gid = _spawner.SpawnCreature(spawnPoint, body, view, config);
        view.EntityGid = gid;
        return gid;
    }
    
    private async UniTaskVoid SpawnEnemiesLoop()
    {
        try
        {
            while (_count < _maxCreatures)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_interval), cancellationToken: _cts.Token);
                SpawnEnemy(_enemyConfig);
                _count++;
            }
        }
        catch (OperationCanceledException) { }
    }

    private void OnDestroy()
    {
        _cts.Cancel();
        _cts.Dispose();
        
        if (_prefabHandle.IsValid()) Addressables.Release(_prefabHandle);

        if (_playerHandle.IsValid()) Addressables.Release(_playerHandle);

        if (_enemyHandle.IsValid()) Addressables.Release(_enemyHandle);
    }
}
}