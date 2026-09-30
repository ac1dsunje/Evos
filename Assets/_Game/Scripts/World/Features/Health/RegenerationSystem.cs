using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Features.Health
{
public struct RegenerationSystem : ISystem
{
    public void Update()
    {
        var delta = W.GetResource<DeltaTimeResource>().Value;
        
        foreach (var entity in W.Query<All<HealthComponent, RegenerationComponent>>().Entities())
        {
            ref var health = ref entity.Ref<HealthComponent>();
            ref readonly var regeneration = ref entity.Read<RegenerationComponent>();
            health.Current = Mathf.Min(health.Current + regeneration.Value * delta, health.Max);
        }
    }
}
}
