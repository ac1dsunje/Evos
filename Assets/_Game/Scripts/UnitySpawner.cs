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
    [SerializeField] private Rigidbody2D _prefab;
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
                var body = Instantiate(_prefab);
                if (_count < 1)
                {
                    _spawner.SpawnPlayer(new Vector2(0, 0), body);
                }
                else
                {
                    _spawner.SpawnEnemy(new Vector2(0, 0), body);
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