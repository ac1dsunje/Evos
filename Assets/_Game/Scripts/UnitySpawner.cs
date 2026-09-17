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
    private const string CreaturePrefabAddress = "Creature_prefab";
    
    [SerializeField] private int _maxCreatures = 500;
    [SerializeField] private float _interval = 1f;
    [SerializeField] private int _count;

    [SerializeField] private Transform _container;

    [SerializeField] private CreatureConfig _playerConfig;
    [SerializeField] private CreatureConfig _enemyConfig;
    
    [Inject] private CreatureSpawner _spawner;
    
    private CancellationTokenSource _cts;
    private AsyncOperationHandle<GameObject> _prefabHandle;
    private GameObject _prefab;
    
    public event Action<EntityGID> OnPlayerSpawned;
    
    private async UniTaskVoid Start()
    {
        _cts = new CancellationTokenSource();
        
        try
        {
            await LoadPrefabAsync(_cts.Token);
            
            SpawnPlayer(_playerConfig);
            
            SpawnEnemiesLoop().Forget();
        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception e)
        {
            Debug.LogError($"[UnitySpawner] Failed to initialize: {e}");
        }
    }
    
    private async UniTask LoadPrefabAsync(CancellationToken token)
    {
        _prefabHandle = Addressables.LoadAssetAsync<GameObject>(CreaturePrefabAddress);
    
        _prefab = await _prefabHandle.ToUniTask(cancellationToken: token);
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
        var go = Instantiate(_prefab, _container);
        var view = go.GetComponent<EntityView>();
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
        if (_cts != null)
        {
            _cts.Cancel();
            _cts.Dispose();
        }
        
        if (_prefabHandle.IsValid())
        {
            Addressables.Release(_prefabHandle);
        }
    }
}
}