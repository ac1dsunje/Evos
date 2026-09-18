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
    [SerializeField] private int _maxCreatures = 500;
    [SerializeField] private float _interval = 1f;
    [SerializeField] private Transform _container;
    
    [Inject] private CreatureSpawner _spawner;
    
    private CancellationTokenSource _cts;
    
    public event Action<EntityGID> OnPlayerSpawned;
    
    private W.NamedResource<EntityView> _prefabResource;
    private W.NamedResource<CreatureConfig> _playerConfigResource;
    private W.NamedResource<CreatureConfig> _enemyConfigResource;
    
    private void Start()
    {
        _cts = new CancellationTokenSource();
        
        _prefabResource = new W.NamedResource<EntityView>("Creature_prefab");
        _playerConfigResource = new W.NamedResource<CreatureConfig>("Creature_player_config");
        _enemyConfigResource = new W.NamedResource<CreatureConfig>("Creature_mossGolem_config");
        
        SpawnPlayer(_playerConfigResource.Value);
        SpawnEnemiesLoop().Forget();
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
        var view = Instantiate(_prefabResource.Value, _container);
        var body = view.Body;
        var render = view.Renderer;
        
        render.sprite = config.Sprite;
        view.transform.position = spawnPoint;
        
        var gid = _spawner.SpawnCreature(body, view, config);
        view.EntityGid = gid;
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
                await UniTask.Delay(TimeSpan.FromSeconds(_interval), cancellationToken: _cts.Token);
                if (CountCreatures() >= _maxCreatures) continue;
                SpawnEnemy(_enemyConfigResource.Value);
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