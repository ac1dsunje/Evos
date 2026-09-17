using System;
using _Game.Scripts.ECS.Core.Systems;
using _Game.Scripts.ECS.Core.Systems.Health;
using _Game.Scripts.ECS.Core.Systems.Input;
using _Game.Scripts.ECS.Core.Systems.Movement;
using _Game.Scripts.ECS.Features.Collisions;
using _Game.Scripts.ECS.Features.Endurance;
using _Game.Scripts.ECS.Features.Hunger;
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

        GameSys.Add(new StatsInitSystem(), order: 0);
        GameSys.Add(new PlayerInputCheckSystem(), order: 1);
        GameSys.Add(new AIInputCheckSystem(), order: 1);
        GameSys.Add(new FacingSystem(), order: 2);
        GameSys.Add(new PositionSynchronizerSystem(), order: 3);
        GameSys.Add(new RegenerationSystem(), order: 4);
        GameSys.Add(new EnduranceRecoverySystem(), order: 5);
        GameSys.Add(new LosingHungerSystem(), order: 7);
        GameSys.Add(new CollisionDamageSystem(), order: 7);
        GameSys.Add(new DamageSystem(), order: 8);
        GameSys.Add(new DeathCheckSystem(), order: 9);
        GameSys.Add(new DeathSystem(), order: 10);
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