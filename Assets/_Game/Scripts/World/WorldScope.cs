using _Game.Scripts.World.Configuration;
using _Game.Scripts.World.Pool;
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
    [SerializeField] private CreatureConfig _playerConfig;
    [SerializeField] private CreatureConfig _slimeConfig;
    
    protected override void Configure(IContainerBuilder builder)
    {
        W.Create();
        GameSys.Create();
        FixedSys.Create();

        EcsDebug<GameWorld>.AddWorld<WorldSystems>();
        EcsDebug<GameWorld>.AddWorld<FixedSystems>();

        W.Types().RegisterAll();
        W.Initialize();
        
        var pool = new ObjectPool<CreatureView>(_creatureViewPrefab, prewarmCount: 10);
        W.SetResource(new CreatureViewPoolResource { Pool = pool });
        W.SetResource(new CreatureConfigsResource
        {
            PlayerConfig = _playerConfig,
            SlimeConfig = _slimeConfig
        });

        GameSys.Add(new PlayerSpawnSystem());
        GameSys.Add(new EnemySpawnSystem());
        
        GameSys.Add(new ViewCreatingSystem());
        
        GameSys.Add(new PlayerInputSystem());
        GameSys.Add(new RandomInputSystem());
        
        GameSys.Add(new FacingSystem());

        FixedSys.Add(new RigidBodyMoverSystem());
        FixedSys.Add(new PositionUpdateSystem());
        
        GameSys.Add(new RegenerationSystem());
        
        GameSys.Initialize();
        FixedSys.Initialize();
        
        builder.RegisterEntryPoint<WorldUpdater>();
    }

    protected override void OnDestroy()
    {
        FixedSys.Destroy();
        GameSys.Destroy();
        W.Destroy();
    }
}
}
