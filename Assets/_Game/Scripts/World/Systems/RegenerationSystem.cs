using _Game.Scripts.World.Components;
using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Systems
{
public struct RegenerationSystem : ISystem
{
    public void Update()
    {
        var delta = W.GetResource<DeltaTimeResource>().Value;
        
        foreach (var entity in W.Query<All<HealthComponent>>().Entities())
        {
            ref var health = ref entity.Ref<HealthComponent>();
            
            health.Current = Mathf.Min(health.Current + delta, health.Max);
        }
    }
}
}