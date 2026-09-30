using System.Collections.Generic;
using _Game.Scripts.World.Configuration;
using _Game.Scripts.World.Entities;
using _Game.Scripts.World.Features.Health;
using _Game.Scripts.World.Features.InputManagement;
using _Game.Scripts.World.Features.Movement;
using _Game.Scripts.World.Features.Spawn;
using _Game.Scripts.World.Pool;
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
    [SerializeField] private List<ViewPoolConfig> _viewPools = new();
    [SerializeField] private CreatureConfig _playerConfig;
    [SerializeField] private CreatureConfig _slimeConfig;
    
    protected override void Configure(IContainerBuilder builder)
    {
        W.Create();
        GameSys.Create();
        InputSys.Create();
        FixedSys.Create();

        EcsDebug<GameWorld>.AddWorld<GameSystems>();
        EcsDebug<GameWorld>.AddWorld<InputSystems>();
        EcsDebug<GameWorld>.AddWorld<FixedSystems>();

        W.Types().RegisterAll();
        W.Initialize();
        
        var pools = new Dictionary<EntityType, ObjectPool<EntityView>>();
        foreach (var config in _viewPools)
        {
            pools[config.EntityType] = new ObjectPool<EntityView>(config.Prefab, prewarmCount: config.PrewarmCount);
        }
        W.SetResource(new ViewPoolResource { Pools = pools });
        W.SetResource(new CreatureConfigsResource
        {
            PlayerConfig = _playerConfig,
            SlimeConfig = _slimeConfig
        });

        GameSys
            .Add(new PlayerSpawnSystem())
            .Add(new EnemySpawnSystem())
            .Add(new ViewCreatingSystem())
            .Add(new RegenerationSystem());

        InputSys
            .Add(new PlayerInputSystem())
            .Add(new RandomInputSystem())
            .Add(new FacingSystem());
        
        FixedSys
            .Add(new RigidBodyMoverSystem())
            .Add(new PositionUpdateSystem());
        
        GameSys.Initialize();
        InputSys.Initialize();
        FixedSys.Initialize();
        
        builder.RegisterEntryPoint<WorldUpdater>();
    }

    protected override void OnDestroy()
    {
        FixedSys.Destroy();
        InputSys.Destroy();
        GameSys.Destroy();
        W.Destroy();
    }
}
}
