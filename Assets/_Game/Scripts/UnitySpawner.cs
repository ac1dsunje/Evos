using System;
using System.Threading;
using _Game.Scripts.ECS;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace _Game.Scripts
{
public class UnitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _maxEntities = 5;
    [SerializeField] private float _interval = 1f;
    [SerializeField] private int _count;
    
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
                var entity = Instantiate(_prefab);
                var body = entity.GetComponent<Rigidbody2D>();
                var view = entity.GetComponent<EntityView>();
                
                view.SetEntity(_count < 1
                    ? _spawner.SpawnPlayer(new Vector2(0, 0), body, view)
                    : _spawner.SpawnEnemy(new Vector2(0, 0), body, view));
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