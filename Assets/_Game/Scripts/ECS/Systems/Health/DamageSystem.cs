using System;
using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats.Defense;
using _Game.Scripts.ECS.Events;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems.Health
{
public struct DamageSystem : ISystem
{
    private EventReceiver<GameWorld, DamageEvent> _receiver;
    
    public void Init()
    {
        _receiver = W.RegisterEventReceiver<DamageEvent>();
    }
    
    public void Update()
    {
        foreach (var e in _receiver)
        {
            if (!e.Value.Target.TryUnpack<GameWorld>(out var target)) 
                continue;
            
            if (!target.Has<HealthComponent>()) continue;
            
            ref var health = ref target.Mut<HealthComponent>();
            
            var resistance = target.Has<DamageResistanceComponent>()
                ? target.Ref<DamageResistanceComponent>().Value
                : 0f;
            
            var effectiveRes = MathF.Max(0f, resistance - e.Value.IgnoreResistance);
            var multiplier = 1f - effectiveRes / 100f;
            
            health.Value -= e.Value.Damage * multiplier;
        }
    }
}
}