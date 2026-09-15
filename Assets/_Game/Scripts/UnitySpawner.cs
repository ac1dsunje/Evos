using System;
using System.Threading;
using _Game.Scripts.ECS;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace _Game.Scripts
{
public class UnitySpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _prefab;
    [SerializeField] private int _maxEntities = 5;
    
    [Inject] private EntitySpawner _spawner;
    
    private CancellationTokenSource _cts;
    private int _count;
    
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
                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: _cts.Token);
                var body = Instantiate(_prefab);
                _spawner.Spawn(new Vector2(0, 0), body);
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