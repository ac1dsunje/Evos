using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Requests;
using _Game.Scripts.ECS.Components.Stats;
using _Game.Scripts.ECS.Tags;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems
{
public struct DamageSystem : ISystem
{
    public void Update()
    {
        foreach (var eventEntity in W.Query<All<DamageRequest>>().Entities())
        {
            ref var evt = ref eventEntity.Ref<DamageRequest>();
            var target = evt.Target;
                
            if (target.IsEnabled)
            {
                ref var healthComp = ref target.Ref<HealthComponent>();
                ref var maxHealthComp = ref target.Ref<MaxHealthComponent>();
                ref var extraLives = ref target.Ref<ExtraLivesComponent>();
                
                healthComp.Value -= evt.Damage;
                
                if (healthComp.Value <= 0)
                {
                    if (extraLives.Value > 0)
                    {
                        healthComp.Value = maxHealthComp.Value;
                        extraLives.Value--;
                    }
                    else
                    {
                        target.Set<DeadTag>();
                    }
                }
            }
            
            eventEntity.Destroy();
        }
    }
}
}