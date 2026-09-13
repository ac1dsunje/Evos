using _Game.Scripts.ECS;
using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace _Game.Scripts
{
public class SpawnerTester : IStartable
{
    [Inject] private EntitySpawner _spawner;

    public void Start()
    {
        for (var i = 0; i < 40; i++)
        {
            _spawner.Spawn(Random.Range(5, 10));
        }
    }
}
}