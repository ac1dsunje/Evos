using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Core.EntityTypes;
using _Game.Scripts.ECS.Core.WorldResources;
using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Config;
using _Game.Scripts.ECS.Features.Experience;
using FFS.Libraries.StaticEcs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Scripts.ECS
{
public class CreatureSpawnerSystem : ISystem
{
    private EntityView _prefab;
    private CreaturesSpawnerConfig _config;
    private float _timer;
    
    public void Init()
    {
        _prefab = W.GetResource<EntityView>("Creature_prefab");
        _config = W.GetResource<CreaturesSpawnerConfig>("Creature_spawner_config");
        SpawnCreature(
            _config.Player, 
            Vector2.zero
            );
    }
    
    public void Update()
    {
        var dt = W.GetResource<DeltaTimeResource>().Value;
        _timer += dt;
        if (!(_timer >= _config.Interval)) return;
        _timer -= _config.Interval;
        
        if (CountCreatures() >= _config.MaxCreatures) return;
        SpawnCreature(
            _config.Enemies[Random.Range(0, _config.Enemies.Count)], 
            new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f))
        );
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
            new ExperienceComponent { Set = config.Experience.Set });

        var view = Object.Instantiate(_prefab);
        var body = view.Body;
        
        view.Renderer.sprite = config.Sprite;
        
        view.transform.position = position;
        view.EntityGid = creature.GID;
        
        creature.Set(
            new CreatureViewComponent { View = view },
            new RigidBodyComponent { Body = body }
            );
    }
}
}