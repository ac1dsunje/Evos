using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using _Game.Scripts.ECS.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class EntitySpawner
{
    public World<GameWorld>.Entity SpawnPlayer(Vector2 position, Rigidbody2D rigidBody, EntityView view)
    {
        var entity = CreateBaseEntity(position, rigidBody, view);
        entity.Set<PlayerControlledTag>();
        return entity;
    }
    
    public World<GameWorld>.Entity SpawnEnemy(Vector2 position, Rigidbody2D rigidBody, EntityView view)
    {
        var entity = CreateBaseEntity(position, rigidBody, view);
        entity.Set<AIControlledTag>();
        return entity;
    }
    
    private World<GameWorld>.Entity CreateBaseEntity(Vector2 position, Rigidbody2D rigidBody, EntityView view)
    {
        return W.NewEntity<Default>().Set(
            new PositionComponent { Position = position },
            new InputComponent { Direction = Vector2.zero },
            new RigidBodyComponent { Body = rigidBody },
            new ViewComponent { View = view },
            
            new PhysicalDamageComponent { Value = 2 },
            
            new HealthComponent { Value = 5 },
            new MaxHealthComponent { Value = 10 },
            new RegenerationComponent { Value = 1 },
            
            new MaxSpeedComponent { Value = 1 }
        );
    }
}
}