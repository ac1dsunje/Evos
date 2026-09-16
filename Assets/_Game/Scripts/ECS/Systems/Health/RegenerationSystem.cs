using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats.Health;
using _Game.Scripts.ECS.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems.Health
{
public struct RegenerationSystem : ISystem
{
    public void Update()
    {
        var deltaTime = W.GetResource<DeltaTimeResource>().Value;
        
        foreach (var entity in W.Query<All<HealthComponent, MaxHealthComponent, RegenerationComponent>>().Entities())
        {
            ref var current = ref entity.Ref<HealthComponent>();
            ref var max = ref entity.Ref<MaxHealthComponent>();
            ref var regeneration = ref entity.Ref<RegenerationComponent>();

            current.Value = Mathf.Min(current.Value + regeneration.Value * deltaTime, max.Value);
        }
    }
}
}