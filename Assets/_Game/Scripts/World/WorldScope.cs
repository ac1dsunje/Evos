using _Game.Scripts.World.Systems;
using _Game.Scripts.World.View;
using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.World
{
public class WorldScope : LifetimeScope
{
    [SerializeField] private CreatureView _creatureViewPrefab;
    
    protected override void Configure(IContainerBuilder builder)
    {
        W.Create();
        GameSys.Create();
        FixedSys.Create();

        EcsDebug<GameWorld>.AddWorld<WorldSystems>();
        EcsDebug<GameWorld>.AddWorld<FixedSystems>();

        W.Types().RegisterAll();
        W.Initialize();
        
        W.SetResource(new CreatureViewPrefabResource { Prefab = _creatureViewPrefab });

        GameSys.Add(new SpawnerSystem());
        
        GameSys.Add(new ViewCreatingSystem());
        
        GameSys.Add(new PlayerInputSystem());
        GameSys.Add(new RandomInputSystem());

        FixedSys.Add(new RigidBodyMoverSystem());
        
        GameSys.Add(new RegenerationSystem());
        
        GameSys.Initialize();
        FixedSys.Initialize();
        
        builder.RegisterEntryPoint<WorldUpdater>();
    }
}
}
