using _Game.Scripts.ECS.Core;
using _Game.Scripts.ECS.Core.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Endurance
{
public struct EnduranceRecoverySystem : ISystem
{
    public void Update()
    {
        var deltaTime = W.GetResource<DeltaTimeResource>().Value;
        
        foreach (var entity in W.Query<All<MaxEnduranceComponent, EnduranceRecoveryComponent, EnduranceComponent>>().Entities())
        {
            ref readonly var max = ref entity.Read<MaxEnduranceComponent>();
            ref readonly var recovery = ref entity.Read<EnduranceRecoveryComponent>();
            ref var current = ref entity.Mut<EnduranceComponent>();

            current.Value = Mathf.Min(current.Value + recovery.Value * deltaTime, max.Value);
        }
    }
}
}