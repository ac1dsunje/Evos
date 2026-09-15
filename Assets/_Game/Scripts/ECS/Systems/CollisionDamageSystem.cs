using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Events;
using _Game.Scripts.ECS.Components.Stats;
using _Game.Scripts.ECS.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
public struct CollisionDamageSystem : ISystem
{
    public void Update()
    {
        foreach (var eventEntity in W.Query<All<CollisionDamageEvent>>().Entities())
        {
            ref var evt = ref eventEntity.Ref<CollisionDamageEvent>();
                
            var attacker = evt.Attacker;
            var target = evt.Target;
            Debug.Log($"start collision event!");
            
            if (attacker.IsEnabled && target.IsEnabled)
            {
                Debug.Log($"{evt.Attacker} hit {evt.Target}");
                ref var damageComp = ref attacker.Ref<PhysicalDamageComponent>();
                ref var healthComp = ref target.Ref<HealthComponent>();

                healthComp.Value -= damageComp.Value;

                if (healthComp.Value <= 0)
                {
                    target.Set<DeadTag>();
                }
            }

            eventEntity.Destroy();
        }
    }
}
}