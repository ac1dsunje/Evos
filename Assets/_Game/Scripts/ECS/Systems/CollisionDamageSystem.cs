using _Game.Scripts.ECS.Components.Requests;
using _Game.Scripts.ECS.Components.Stats;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems
{
public struct CollisionDamageSystem : ISystem
{
    public void Update()
    {
        foreach (var eventEntity in W.Query<All<CollisionRequest>>().Entities())
        {
            ref var evt = ref eventEntity.Ref<CollisionRequest>();
            
            var attacker = evt.Attacker;
            var target = evt.Target;
            
            if (attacker.IsEnabled && target.IsEnabled)
            {
                ref var damageComp = ref attacker.Ref<PhysicalDamageComponent>();
                
                W.NewEntity<Default>().Set(new DamageRequest
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