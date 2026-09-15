using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using _Game.Scripts.ECS.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class EntitySpawner
{
    public void Spawn(float startHp, Vector2 startPos, float speed, Rigidbody2D rigidBody)
    {
        W.NewEntity<Default>().Set(
            new InputComponent {Direction = Vector2.zero},
            new RigidBodyComponent { Body = rigidBody },
            
            new HealthComponent { Value = 1 },
            new MaxHealthComponent { Value = startHp },
            new RegenerationComponent { Value = 1},
            
            new PositionComponent { Position = startPos },
            new MaxSpeedComponent { Value = speed }
        ).Set<PlayerControlledTag>();
    }
}
}