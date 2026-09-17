using System;
using System.Collections.Generic;
using _Game.Scripts.ECS.Core.Components;
using _Game.Scripts.ECS.Core.Components.Defense;
using _Game.Scripts.ECS.Core.Components.Health;
using _Game.Scripts.ECS.Core.Events;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Core.Systems
{
public struct DamageSystem : ISystem
{
    private EventReceiver<GameWorld, DamageEvent> _receiver;
    private List<DamageEvent> _reflectionEvents;
    
    public void Init()
    {
        _receiver = W.RegisterEventReceiver<DamageEvent>();
        _reflectionEvents = new List<DamageEvent>();
    }
    
    public void Update()
    {
        _reflectionEvents.Clear();
        
        foreach (var e in _receiver)
        {
            if (!e.Value.Target.TryUnpack<GameWorld>(out var target)) 
                continue;
            
            if (!target.Has<HealthComponent>()) continue;
            
            ref var health = ref target.Mut<HealthComponent>();
            
            var resistance = target.Has<DamageResistanceComponent>()
                ? target.Read<DamageResistanceComponent>().Value
                : 0f;
            
            var effectiveRes = MathF.Max(0f, resistance - e.Value.IgnoreResistance);
            var multiplier = 1f - effectiveRes / 100f;
            
            var appliedDamage = e.Value.Damage * multiplier;
            
            health.Value -= appliedDamage;

            var reflect = target.Has<DamageReflectionComponent>()
                ? target.Read<DamageReflectionComponent>().Value / 100f * appliedDamage
                : 0f;

            if (reflect <= 0f) continue;
            if (!e.Value.Source.TryUnpack<GameWorld>(out var source)) continue;
            
            _reflectionEvents.Add(new DamageEvent
            {
                Source = default,
                Target = source.GID,
                Damage = reflect,
                IgnoreResistance = 100
            });
        }
        
        foreach (var t in _reflectionEvents)
        {
            W.SendEvent(t);
        }
    }
}
}