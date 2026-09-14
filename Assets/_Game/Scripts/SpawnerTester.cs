using System;
using System.Threading;
using _Game.Scripts.ECS;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace _Game.Scripts
{
public class SpawnerTester : IStartable, IDisposable
{
    [Inject] private EntitySpawner _spawner;
    
    private CancellationTokenSource _cts;
    
    public void Start()
    {
        _cts = new CancellationTokenSource();
        SpawnLoop().Forget();
    }
    
    private async UniTaskVoid SpawnLoop()
    {
        try
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: _cts.Token);
                _spawner.Spawn(Random.Range(5, 10));
            }
        }
        catch (OperationCanceledException)
        {
            
        }
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}
}