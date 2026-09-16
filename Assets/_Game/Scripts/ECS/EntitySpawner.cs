using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using _Game.Scripts.ECS.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class EntitySpawner
{
    public World<GameWorld>.Entity SpawnPlayer(Vector2 position, Rigidbody2D rigidBody, EntityView view, EntityConfig config)
    {
        var entity = CreateBaseEntity(position, rigidBody, view, config);
        entity.Set<PlayerControlledTag>();
        return entity;
    }
    
    public World<GameWorld>.Entity SpawnEnemy(Vector2 position, Rigidbody2D rigidBody, EntityView view, EntityConfig config)
    {
        var entity = CreateBaseEntity(position, rigidBody, view, config);
        entity.Set<AIControlledTag>();
        return entity;
    }
    
    private World<GameWorld>.Entity CreateBaseEntity(Vector2 position, Rigidbody2D rigidBody, EntityView view, EntityConfig config)
    {
        return W.NewEntity<Default>().Set(
            new PositionComponent { Position = position },
            new InputComponent { Direction = Vector2.zero },
            new RigidBodyComponent { Body = rigidBody },
            new ViewComponent { View = view },
            
            new PhysicalDamageComponent { Value = config.PhysicalDamage },
            
            new MaxHungerComponent { Value = config.MaxHunger },
            new HungerComponent { Value = config.MaxHunger },
            
            new HealthComponent { Value = config.MaxHealth },
            new MaxHealthComponent { Value = config.MaxHealth },
            new RegenerationComponent { Value = config.Regeneration },
            
            new MaxSpeedComponent { Value = config.MaxSpeed }
        );
    }
}
}