using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Core;
using _Game.Scripts.ECS.Core.EntityTypes;
using _Game.Scripts.ECS.Core.Timer;
using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Config;
using _Game.Scripts.ECS.Features.Experience;
using FFS.Libraries.StaticEcs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Scripts.ECS.Features.Spawn
{
public class CreatureSpawnerSystem : ISystem
{
    private EntityView _prefab;
    private CreaturesSpawnerConfig _config;
    
    public void Init()
    {
        _config = W.GetResource<CreaturesSpawnerConfig>("Creature_spawner_config");
        _prefab = W.GetResource<EntityView>("Creature_prefab");
        
        W.NewEntity<CreatureSpawner>().Set(
            new TimerComponent { Interval = _config.Interval },
            new NameComponent { Value = "Creature Spawner" });
        
        SpawnCreature(
            _config.Player, 
            Vector2.zero);
    }
    
    public void Update()
    {
        foreach (var e in W.Query<EntityIs<CreatureSpawner>, All<TimerComponent>>().Entities())
        {
            ref var timer = ref e.Ref<TimerComponent>();
            if (timer.Current < _config.Interval) return;
            
            timer.Current -= _config.Interval;
            
            if (CountCreatures() >= _config.MaxCreatures) return;
            
            SpawnCreature(
                _config.Enemies[Random.Range(0, _config.Enemies.Count)], 
                new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f))
            );
        }
    }
    
    private int CountCreatures()
    {
        var count = 0;
        foreach (var _ in W.Query<EntityIs<Creature>>().Entities())
        {
            count++;
        }
        return count;
    }
    
    private void SpawnCreature(CreatureConfig config, Vector2 position)
    {
        var creature = W.NewEntity<Creature>().Set(
            new CreatureConfigComponent { Config = config },
            new ExperienceComponent { Set = config.Experience.Set },
            new NameComponent {Value = config.name});

        var view = Object.Instantiate(_prefab);
        var body = view.Body;
        
        view.Renderer.sprite = config.Sprite;
        
        view.transform.position = position;
        view.EntityGid = creature.GID;
        
        creature.Set(
            new TransformComponent { Transform = view.transform },
            new RigidBodyComponent { Body = body });
    }
}
}