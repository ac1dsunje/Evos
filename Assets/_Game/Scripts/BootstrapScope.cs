using _Game.Scripts.Components;
using _Game.Scripts.Systems;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts
{
public class BootstrapScope: LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        W.Create();
        W.Types().RegisterAll(); 
        W.Initialize();

        GameSys.Create();
        GameSys.Add(new DamageOverTimeSystem(), order: 0);
        GameSys.Initialize();

        builder.Register<EntitySpawner>(Lifetime.Singleton);
        builder.RegisterEntryPoint<EcsUpdateBridge>().AsSelf();

        builder.RegisterEntryPoint<SpawnerTester>(Lifetime.Scoped);
    }
}

public class EcsUpdateBridge : ITickable
{
    public void Tick()
    {
        GameSys.Update();
        W.Tick();
    }
}

}
