using _Game.Scripts.ECS.Core;
using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Input;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Dashing
{
public struct DashSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<RigidBodyComponent, DashRangeComponent, DashTag, InputComponent>>().Entities())
        {
            ref readonly var input = ref entity.Read<InputComponent>();
            ref readonly var range = ref entity.Read<DashRangeComponent>();
            ref var body = ref entity.Ref<RigidBodyComponent>();
            
            body.Body.AddForce(input.Current * range.Value, ForceMode2D.Impulse);
            entity.Delete<DashTag>();
        }
    }
}
}