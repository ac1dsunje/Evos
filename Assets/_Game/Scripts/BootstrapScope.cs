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
        FixedSys.Create();
        
        EcsDebug<GameWorld>.AddWorld<GameSystems>();
        EcsDebug<GameWorld>.AddWorld<FixedSystems>();
        
        W.Types().RegisterAll(); 
        W.Initialize();

        GameSys.Add(new PlayerInputCheckSystem(), order: 0);
        GameSys.Add(new AIInputCheckSystem(), order: 0);
        GameSys.Add(new PositionSynchronizerSystem(), order: 1);
        GameSys.Add(new RegenerationSystem(), order: 2);
        GameSys.Add(new EnduranceRecoverySystem(), order: 3);
        GameSys.Add(new CollisionDamageSystem(), order: 4);
        GameSys.Add(new DamageSystem(), order: 5);
        GameSys.Add(new DeathSystem(), order: 6);
        GameSys.Initialize();
        
        FixedSys.Add(new RigidBodyMoverSystem(), order: 2);
        FixedSys.Initialize();
        
        
        builder.RegisterEntryPoint<WorldUpdater>().AsSelf();

        builder.Register<EntitySpawner>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<UnitySpawner>();
    }

    protected override void OnDestroy()
    {
        GameSys.Destroy();
        W.Destroy();
        base.OnDestroy();
    }
}
}
