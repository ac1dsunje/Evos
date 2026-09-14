using _Game.Scripts.ECS;
using _Game.Scripts.ECS.Systems;
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
        
        
        builder.RegisterEntryPoint<WorldUpdater>().AsSelf();

        builder.Register<EntitySpawner>(Lifetime.Singleton);

        builder.RegisterEntryPoint<SpawnerTester>(Lifetime.Scoped);
    }

    protected override void OnDestroy()
    {
        GameSys.Destroy();
        W.Destroy();
        base.OnDestroy();
    }
}
}
