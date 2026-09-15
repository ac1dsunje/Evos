using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using _Game.Scripts.ECS.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
public struct RegenerationSystem : ISystem
{
    private float _timer;
    private const float Interval = 1.0f;
    
    public void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer < Interval) return;
        
        _timer = 0f;
        
        foreach (var entity in W.Query<
                     All<HealthComponent, MaxHealthComponent, RegenerationComponent>, 
                     None<DeadTag>
                 >().Entities())
        {
            ref var current = ref entity.Ref<HealthComponent>();
            ref var max = ref entity.Ref<MaxHealthComponent>();
            ref var regeneration = ref entity.Ref<RegenerationComponent>();

            current.Value = Mathf.Min(current.Value + regeneration.Value, max.Value);
        }
    }
}
}