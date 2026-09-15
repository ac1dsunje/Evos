using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
public struct RigidBodyMoverSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<
                     MaxSpeedComponent, 
                     RigidBodyComponent, 
                     InputComponent
                 >>().Entities())
        {
            ref var speed  = ref entity.Ref<MaxSpeedComponent>();
            ref var rigidBody = ref entity.Ref<RigidBodyComponent>();
            ref var input = ref entity.Ref<InputComponent>();

            if (rigidBody.Body == null) return;
            
            rigidBody.Body.linearVelocity = new Vector2(input.Direction.x, input.Direction.y) * speed.Value;
        }
    }
}
}