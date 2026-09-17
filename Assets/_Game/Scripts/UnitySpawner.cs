using System;
using System.Threading;
using _Game.Scripts.Configs;
using _Game.Scripts.ECS;
using Cysharp.Threading.Tasks;
using FFS.Libraries.StaticEcs;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace _Game.Scripts
{
public class UnitySpawner : MonoBehaviour
{
    [SerializeField] private EntityView _prefab;
    [SerializeField] private int _maxCreatures = 500;
    [SerializeField] private float _interval = 1f;
    [SerializeField] private int _count;

    [SerializeField] private Transform _container;

    [SerializeField] private CreatureConfig _playerConfig;
    [SerializeField] private CreatureConfig _enemyConfig;
    
    [Inject] private CreatureSpawner _spawner;
    
    private CancellationTokenSource _cts;
    public event Action<EntityGID> OnPlayerSpawned;
    
    private void Start()
    {
        SpawnPlayer(_playerConfig);
        
        _cts = new CancellationTokenSource();
        SpawnEnemiesLoop().Forget();
    }
    
    private void SpawnPlayer(CreatureConfig config)
    {
        var gid = SpawnCreature(config, Vector2.zero);
        OnPlayerSpawned?.Invoke(gid);
    }

    private void SpawnEnemy(CreatureConfig config)
    {
        var gid = SpawnCreature(config, new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)));
    }

    private EntityGID SpawnCreature(CreatureConfig config, Vector2 spawnPoint)
    {
        var view  = Instantiate(_prefab, _container);
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
    }
}
}