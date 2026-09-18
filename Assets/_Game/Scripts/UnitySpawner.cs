using System;
using System.Threading;
using _Game.Scripts.Configs;
using _Game.Scripts.ECS;
using _Game.Scripts.ECS.Core.EntityTypes;
using Cysharp.Threading.Tasks;
using FFS.Libraries.StaticEcs;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace _Game.Scripts
{
public class UnitySpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    
    [Inject] private CreatureSpawner _spawner;
    
    private CancellationTokenSource _cts;
    
    public event Action<EntityGID> OnPlayerSpawned;
    
    private CreatureConfig _playerConfig;
    private W.NamedResource<CreaturesSpawnerConfig> _config;
    
    private void Start()
    {
        _cts = new CancellationTokenSource();
        _config = new W.NamedResource<CreaturesSpawnerConfig>("Creature_spawner_config");
        
        SpawnPlayer(_config.Value.Player);
        SpawnEnemiesLoop().Forget();
    }
    
    private void SpawnPlayer(CreatureConfig config)
    {
        var gid = SpawnCreature(config, Vector2.zero);
        OnPlayerSpawned?.Invoke(gid);
    }

    private void SpawnEnemy()
    {
        SpawnCreature(
            _config.Value.Enemies[Random.Range(0, _config.Value.Enemies.Count)], 
            new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f))
            );
    }

    private EntityGID SpawnCreature(CreatureConfig config, Vector2 position)
    {
        var gid = _spawner.SpawnCreature(config, position, _container);
        return gid;
    }
    
    private int CountCreatures()
    {
        var count = 0;
        foreach (var _ in W.Query<EntityIs<Creature>>().Entities())
        {
            count++;
        }
        return count;
    }

    private async UniTaskVoid SpawnEnemiesLoop()
    {
        try
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_config.Value.Interval), cancellationToken: _cts.Token);
                if (CountCreatures() >= _config.Value.MaxCreatures) continue;
                SpawnEnemy();
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
    }
}
}