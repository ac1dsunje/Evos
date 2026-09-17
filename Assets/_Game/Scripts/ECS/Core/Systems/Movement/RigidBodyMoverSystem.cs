using _Game.Scripts.ECS.Core.Components;
using _Game.Scripts.ECS.Core.Components.Stats.Movement;
using _Game.Scripts.ECS.Core.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Core.Systems.Movement
{
public struct RigidBodyMoverSystem : ISystem
{
    public void Update()
    {
        var deltaTime = W.GetResource<FixedDeltaTimeResource>().Value;
        
        foreach (var entity in W.Query<All<MaxSpeedComponent, InertiaComponent, AccelerationComponent, 
                     RigidBodyComponent, InputComponent>>().Entities())
        {
            ref readonly var maxSpeed = ref entity.Read<MaxSpeedComponent>();
            ref readonly var input = ref entity.Read<InputComponent>();
            ref readonly var inertia = ref entity.Read<InertiaComponent>();
            ref readonly var acceleration = ref entity.Read<AccelerationComponent>();
            
            ref var rigidBody = ref entity.Ref<RigidBodyComponent>();
            
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