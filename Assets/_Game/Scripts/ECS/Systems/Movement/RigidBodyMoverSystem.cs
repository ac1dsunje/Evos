using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats.Movement;
using _Game.Scripts.ECS.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems.Movement
{
public struct RigidBodyMoverSystem : ISystem
{
    public void Update()
    {
        var deltaTime = W.GetResource<FixedDeltaTimeResource>().Value;
        
        foreach (var entity in W.Query<All<MaxSpeedComponent, InertiaComponent, AccelerationComponent, 
                     RigidBodyComponent, InputComponent>>().Entities())
        {
            ref var maxSpeed = ref entity.Ref<MaxSpeedComponent>();
            ref var rigidBody = ref entity.Ref<RigidBodyComponent>();
            ref var input = ref entity.Ref<InputComponent>();
            ref var inertia = ref entity.Ref<InertiaComponent>();
            ref var acceleration = ref entity.Ref<AccelerationComponent>();
            
            var currentVelocity = rigidBody.Body.linearVelocity;
            var inputDirection = new Vector2(input.Direction.x, input.Direction.y);
            
            if (inputDirection.sqrMagnitude > 0.001f)
            {
                inputDirection = inputDirection.normalized;
                var targetVelocity = inputDirection * maxSpeed.Value;
                
                var accelerationFactor = acceleration.Value * deltaTime;
                currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, accelerationFactor);
            }
            else
            {
                var decelerationFactor = 1f / inertia.Value * deltaTime;
                currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, decelerationFactor);
                
                if (currentVelocity.sqrMagnitude < 0.001f)
                {
                    currentVelocity = Vector2.zero;
                }
            }
            
            if (currentVelocity.sqrMagnitude > maxSpeed.Value * maxSpeed.Value)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed.Value;
            }
            
            rigidBody.Body.linearVelocity = currentVelocity;
        }
    }
}
}