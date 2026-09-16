using System;
using System.Threading;
using _Game.Scripts.Configs;
using _Game.Scripts.ECS;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace _Game.Scripts
{
public class UnitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _maxEntities = 5;
    [SerializeField] private float _interval = 1f;
    [SerializeField] private int _count;

    [SerializeField] private Transform _container;

    [SerializeField] private EntityConfig _playerConfig;
    [SerializeField] private EntityConfig _enemyConfig;
    
    [Inject] private EntitySpawner _spawner;
    
    private CancellationTokenSource _cts;
    
    private void Start()
    {
        _cts = new CancellationTokenSource();
        SpawnLoop().Forget();
    }
    
    private async UniTaskVoid SpawnLoop()
    {
        try
        {
            while (_count < _maxEntities)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_interval), cancellationToken: _cts.Token);
                var entity = Instantiate(_prefab, _container);
                var body = entity.GetComponent<Rigidbody2D>();
                var view = entity.GetComponent<EntityView>();
                var render = entity.GetComponent<SpriteRenderer>();
                
                var spawnPoint = Vector2.zero;
                
                if (_count < 1)
                {
                    entity.transform.position = spawnPoint;
                    view.EntityGid = _spawner.SpawnPlayer(spawnPoint, body, view, _playerConfig);
                    render.sprite = _playerConfig.Sprite;
                }
                else
                {
                    spawnPoint = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
                    entity.transform.position = spawnPoint;
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