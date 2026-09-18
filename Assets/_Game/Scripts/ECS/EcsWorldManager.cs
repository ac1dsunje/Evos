using System;
using System.Threading;
using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Core.Combat;
using _Game.Scripts.ECS.Features.Biomes.Breathing;
using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Collisions;
using _Game.Scripts.ECS.Features.Death;
using _Game.Scripts.ECS.Features.Endurance;
using _Game.Scripts.ECS.Features.Experience;
using _Game.Scripts.ECS.Features.Hunger;
using _Game.Scripts.ECS.Features.Input;
using _Game.Scripts.ECS.Features.Regeneration;
using _Game.Scripts.ECS.Features.Stats;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer.Unity;

namespace _Game.Scripts.ECS
{
public class EcsWorldManager : IInitializable, IDisposable
{
    private CancellationTokenSource _cts;
    
    private AsyncOperationHandle<GameObject> _prefabHandle;
    private AsyncOperationHandle<CreatureConfig> _playerConfigHandle;
    private AsyncOperationHandle<CreatureConfig> _enemyConfigHandle;
    
    public void Initialize()
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
        
        GameSys.Add(new BreathingCheckSystem());
        
        GameSys.Add(new RegenerationCheckSystem());
        GameSys.Add(new RegenerationSystem());
        
        GameSys.Add(new ExperienceUpdateSystem());
        GameSys.Add(new LevelUpdateSystem());
        
        GameSys.Add(new EnduranceRecoverySystem());
        GameSys.Add(new LosingHungerSystem());
        
        GameSys.Add(new CollisionDamageSystem());
        GameSys.Add(new DamageSystem());
        GameSys.Add(new DeathCheckSystem());
        GameSys.Add(new DeathSystem());
        
        GameSys.Initialize();
        
        FixedSys.Add(new RigidBodyMoverSystem(), order: 0);
        
        FixedSys.Initialize();
        
        LoadAssets();
        
        W.SetResource(new HungerDecayRate { Value = 0.2f });
    }
    
    private void LoadAssets()
    {
        _prefabHandle = Addressables.LoadAssetAsync<GameObject>("Creature_prefab");
        var prefab = _prefabHandle.WaitForCompletion();
        var entityView = prefab.GetComponent<EntityView>();
        W.SetResource("Creature_prefab", entityView);
        
        _playerConfigHandle = Addressables.LoadAssetAsync<CreatureConfig>("Creature_player_config");
        var playerConfig = _playerConfigHandle.WaitForCompletion();
        W.SetResource("Creature_player_config", playerConfig);
        
        _enemyConfigHandle = Addressables.LoadAssetAsync<CreatureConfig>("Creature_mossGolem_config");
        var enemyConfig = _enemyConfigHandle.WaitForCompletion();
        W.SetResource("Creature_mossGolem_config", enemyConfig);
    }

    public void Dispose()
    {
        _cts?.Cancel();
        _cts?.Dispose();
        
        if (_prefabHandle.IsValid()) Addressables.Release(_prefabHandle);
        if (_playerConfigHandle.IsValid()) Addressables.Release(_playerConfigHandle);
        if (_enemyConfigHandle.IsValid()) Addressables.Release(_enemyConfigHandle);
        
        GameSys.Destroy();
        FixedSys.Destroy();
        W.Destroy();
    }
}
}