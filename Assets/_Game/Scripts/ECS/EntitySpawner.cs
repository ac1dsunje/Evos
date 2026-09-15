using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using _Game.Scripts.ECS.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class EntitySpawner
{
    public void SpawnPlayer(Vector2 position, Rigidbody2D rigidBody)
    {
        W.NewEntity<Default>().Set(
            new PositionComponent { Position = position },
            new InputComponent { Direction = Vector2.zero },
            new RigidBodyComponent { Body = rigidBody },
            
            new HealthComponent { Value = 5 },
            new MaxHealthComponent { Value = 10 },
            new RegenerationComponent { Value = 1},
            
            new MaxSpeedComponent { Value = 1 }
        ).Set<PlayerControlledTag>();
    }
    
    public void SpawnEnemy(Vector2 position, Rigidbody2D rigidBody)
    {
        W.NewEntity<Default>().Set(
            new PositionComponent { Position = position },
            new InputComponent { Direction = Vector2.zero },
            new RigidBodyComponent { Body = rigidBody },
            
            new HealthComponent { Value = 5 },
            new MaxHealthComponent { Value = 10 },
            new RegenerationComponent { Value = 1},
            
            new MaxSpeedComponent { Value = 1 }
        ).Set<AIControlledTag>();
    }
}
}