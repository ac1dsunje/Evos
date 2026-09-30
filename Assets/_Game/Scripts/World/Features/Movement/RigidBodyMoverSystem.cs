using _Game.Scripts.World.Features.InputManagement;
using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Features.Movement
{
public struct RigidBodyMoverSystem : ISystem
{
    public void Update()
    {
        var deltaTime = W.GetResource<FixedDeltaTimeResource>().Value;
            
        foreach (var entity in W.Query<All<RigidBodyComponent, InputComponent, MovementComponent>>().Entities())
        {
            ref var body = ref entity.Ref<RigidBodyComponent>();
            ref readonly var input = ref entity.Read<InputComponent>();
            ref var movement = ref entity.Ref<MovementComponent>();
                
            var currentVelocity = body.Body.linearVelocity;
            var inputDirection = new Vector2(input.Direction.x, input.Direction.y);
                
            if (inputDirection.sqrMagnitude > 0.001f)
            {
                inputDirection = inputDirection.normalized;
                var targetVelocity = inputDirection * movement.MaxSpeed;
                    
                var accelerationStep = movement.Acceleration * deltaTime;
                currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, accelerationStep);
            }
            else
            {
                var decelerationStep = movement.MaxSpeed / movement.Inertia * deltaTime;
                currentVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, decelerationStep);
            }
                
            if (currentVelocity.sqrMagnitude > movement.MaxSpeed * movement.MaxSpeed)
            {
                currentVelocity = currentVelocity.normalized * movement.MaxSpeed;
            }
                
            body.Body.linearVelocity = currentVelocity;
        }
    }
}
}