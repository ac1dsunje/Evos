using _Game.Scripts.ECS;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts
{
public class SpawnerTester : IStartable
{
    [Inject] private EntitySpawner _spawner;

    public void Start()
    {
        _spawner.Spawn(3f);
        _spawner.Spawn(5f);
        _spawner.Spawn(2f);
    }
}
}