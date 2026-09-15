using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
public struct EnduranceRecoverySystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<
                     MaxEnduranceComponent,
                     EnduranceRecoveryComponent,
                     EnduranceComponent
                 >>().Entities())
        {
            ref var max = ref entity.Ref<MaxEnduranceComponent>();
            ref var recovery = ref entity.Ref<EnduranceRecoveryComponent>();
            ref var current = ref entity.Ref<EnduranceComponent>();

            if (current.Value < max.Value)
            {
                current.Value += recovery.Value;
            }

            current.Value = Mathf.Min(max.Value, current.Value);
        }
    }
}
}