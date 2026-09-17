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
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _maxCreatures = 500;
    [SerializeField] private float _interval = 1f;
    [SerializeField] private int _count;

    [SerializeField] private Transform _container;

    [SerializeField] private EntityConfig _playerConfig;
    [SerializeField] private EntityConfig _enemyConfig;
    
    [Inject] private CreatureSpawner _spawner;
    
    private CancellationTokenSource _cts;
    public event Action<EntityGID> OnPlayerSpawned;
    
    private void Start()
    {
        _cts = new CancellationTokenSource();
        SpawnLoop().Forget();
    }
    
    private async UniTaskVoid SpawnLoop()
    {
        try
        {
            while (_count < _maxCreatures)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_interval), cancellationToken: _cts.Token);
                var creature = Instantiate(_prefab, _container);
                var body = creature.GetComponent<Rigidbody2D>();
                var view = creature.GetComponent<EntityView>();
                var render = creature.GetComponent<SpriteRenderer>();
                
                var spawnPoint = Vector2.zero;
                
                if (_count < 1)
                {
                    creature.transform.position = spawnPoint;
                    var gid = _spawner.SpawnPlayer(spawnPoint, body, view, _playerConfig);
                    view.EntityGid = gid;
                    OnPlayerSpawned?.Invoke(gid);
                    render.sprite = _playerConfig.Sprite;
                }
                else
                {
                    spawnPoint = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
                    creature.transform.position = spawnPoint;
                    view.EntityGid = _spawner.SpawnEnemy(spawnPoint, body, view, _enemyConfig);
                    render.sprite = _enemyConfig.Sprite;
                }

                _count++;
            }
        }
        catch (OperationCanceledException)
        {
            
        }
    }

    private void OnDestroy()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}
}