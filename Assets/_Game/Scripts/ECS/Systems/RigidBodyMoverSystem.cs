using _Game.Scripts.ECS.Components;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
public struct RigidBodyMoverSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<
                     SpeedComponent, 
                     RigidBodyComponent, 
                     InputComponent
                 >>().Entities())
        {
            ref var speed  = ref entity.Ref<SpeedComponent>();
            ref var rigidBody = ref entity.Ref<RigidBodyComponent>();
            ref var input = ref entity.Ref<InputComponent>();

            rigidBody.Body.linearVelocity = new Vector2(input.Direction.x, input.Direction.y) * speed.Value;
        }
    }
}
}