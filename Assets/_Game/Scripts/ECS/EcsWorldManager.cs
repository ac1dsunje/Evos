using System;
using _Game.Scripts.ECS.Core.Systems;
using _Game.Scripts.ECS.Core.Systems.Health;
using _Game.Scripts.ECS.Core.Systems.Input;
using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Collisions;
using _Game.Scripts.ECS.Features.Death;
using _Game.Scripts.ECS.Features.Endurance;
using _Game.Scripts.ECS.Features.Hunger;
using _Game.Scripts.ECS.Features.Regeneration;
using _Game.Scripts.ECS.Features.Stats;
using FFS.Libraries.StaticEcs.Unity;
using VContainer.Unity;

namespace _Game.Scripts.ECS
{
public class EcsWorldManager : IStartable, IDisposable
{
    public void Start()
    {
        W.Create();
        GameSys.Create();
        FixedSys.Create();

        EcsDebug<GameWorld>.AddWorld<GameSystems>();
        EcsDebug<GameWorld>.AddWorld<FixedSystems>();

        W.Types().RegisterAll();
        W.Initialize();

        GameSys.Add(new StatsInitSystem());
        GameSys.Add(new PlayerInputCheckSystem());
        GameSys.Add(new AIInputCheckSystem());
        GameSys.Add(new FacingSystem());
        GameSys.Add(new PositionSynchronizerSystem());
        GameSys.Add(new RegenerationCheckSystem());
        GameSys.Add(new RegenerationSystem());
        GameSys.Add(new EnduranceRecoverySystem());
        GameSys.Add(new LosingHungerSystem());
        GameSys.Add(new CollisionDamageSystem());
        GameSys.Add(new DamageSystem());
        GameSys.Add(new DeathCheckSystem());
        GameSys.Add(new DeathSystem());
        GameSys.Initialize();
        
        FixedSys.Add(new RigidBodyMoverSystem(), order: 0);
        FixedSys.Initialize();
        
        W.SetResource(new HungerDecayRate { Value = 0.2f });
    }

    public void Dispose()
    {
        GameSys.Destroy();
        FixedSys.Destroy();
        W.Destroy();
    }
}
}