using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats.Endurance;
using _Game.Scripts.ECS.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
public struct EnduranceRecoverySystem : ISystem
{
    public void Update()
    {
        var deltaTime = W.GetResource<DeltaTimeResource>().Value;
        
        foreach (var entity in W.Query<All<MaxEnduranceComponent, EnduranceRecoveryComponent, EnduranceComponent>>().Entities())
        {
            ref var max = ref entity.Ref<MaxEnduranceComponent>();
            ref var recovery = ref entity.Ref<EnduranceRecoveryComponent>();
            ref var current = ref entity.Ref<EnduranceComponent>();

            current.Value = Mathf.Min(current.Value + recovery.Value * deltaTime, max.Value);
        }
    }
}
}