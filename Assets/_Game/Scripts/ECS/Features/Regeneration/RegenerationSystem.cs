using _Game.Scripts.ECS.Core.WorldResources;
using _Game.Scripts.ECS.Features.Health;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Regeneration
{
public struct RegenerationSystem : ISystem
{
    public void Update()
    {
        var deltaTime = W.GetResource<DeltaTimeResource>().Value;
        
        foreach (var entity in W.Query<All<HealthComponent, MaxHealthComponent, RegenerationComponent>>().Entities())
        {
            ref var current = ref entity.Mut<HealthComponent>();
            ref readonly var max = ref entity.Read<MaxHealthComponent>();
            ref readonly var regeneration = ref entity.Read<RegenerationComponent>();

            current.Value = Mathf.Min(current.Value + regeneration.Value * deltaTime, max.Value);
        }
    }
}
}