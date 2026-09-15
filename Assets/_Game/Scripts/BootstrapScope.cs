using _Game.Scripts.ECS;
using _Game.Scripts.ECS.Systems;
using FFS.Libraries.StaticEcs.Unity;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts
{
public class BootstrapScope: LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        W.Create();
        GameSys.Create();
        
        EcsDebug<GameWorld>.AddWorld<GameSystems>();
        
        W.Types().RegisterAll(); 
        W.Initialize();

        GameSys.Add(new RigidBodyMoverSystem(), order: 0);
        GameSys.Add(new PositionSynchronizerSystem(), order: 1);
        GameSys.Add(new RegenerationSystem(), order: 2);
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
