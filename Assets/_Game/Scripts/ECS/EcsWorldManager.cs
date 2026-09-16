using System;
using FFS.Libraries.StaticEcs.Unity;
using VContainer.Unity;
using _Game.Scripts.ECS.Systems;
using _Game.Scripts.ECS.Systems.Health;
using _Game.Scripts.ECS.Systems.Input;
using _Game.Scripts.ECS.Systems.Movement;

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
        GameSys.Add(new PositionSynchronizerSystem(), order: 2);
        GameSys.Add(new RegenerationSystem(), order: 3);
        GameSys.Add(new EnduranceRecoverySystem(), order: 4);
        GameSys.Add(new LosingHungerSystem(), order: 5);
        GameSys.Add(new CollisionDamageSystem(), order: 6);
        GameSys.Add(new DamageSystem(), order: 7);
        GameSys.Add(new DeathCheckSystem(), order: 8);
        GameSys.Add(new DeathSystem(), order: 9);
        GameSys.Initialize();
        
        FixedSys.Add(new RigidBodyMoverSystem(), order: 0);
        FixedSys.Add(new PhysicsMaterialSystem(), order: 1);
        FixedSys.Initialize();
    }

    public void Dispose()
    {
        GameSys.Destroy();
        FixedSys.Destroy();
        W.Destroy();
    }
}
}