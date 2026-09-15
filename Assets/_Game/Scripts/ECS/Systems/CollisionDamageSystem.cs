using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Events;
using _Game.Scripts.ECS.Components.Requests;
using _Game.Scripts.ECS.Components.Stats;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems
{
public struct CollisionDamageSystem : ISystem
{
    public void Update()
    {
        foreach (var eventEntity in W.Query<All<CollisionEvent>>().Entities())
        {
            ref var evt = ref eventEntity.Ref<CollisionEvent>();
            
            var attacker = evt.Attacker;
            var target = evt.Target;
            
            if (attacker.IsEnabled && target.IsEnabled)
            {
                ref var damageComp = ref attacker.Ref<PhysicalDamageComponent>();
                
                W.NewEntity<Default>().Set(new DamageEvent
                {
                    Target = target,
                    Damage = damageComp.Value
                });
            }
            
            eventEntity.Destroy();
        }
    }
}
}