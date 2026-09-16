using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Requests;
using _Game.Scripts.ECS.Components.Stats;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems
{
public struct StatsInitSystem : ISystem
{
    public void Update()
    {
        foreach (var cmdEntity in W.Query<All<InitStatsRequest>>().Entities())
        {
            ref var cmd = ref cmdEntity.Ref<InitStatsRequest>();
            var target = cmd.Target;
            var config = cmd.Config;

            if (target.IsEnabled)
            {
                target.Set(new MaxHealthComponent { Value = config.MaxHealth });
                target.Set(new HealthComponent { Value = config.MaxHealth });
                target.Set(new ExtraLivesComponent { Value = config.ExtraLives });
                target.Set(new RegenerationComponent { Value = config.Regeneration });
                
                target.Set(new MaxHungerComponent { Value = config.MaxHunger });
                target.Set(new HungerComponent { Value = config.MaxHunger });
                
                target.Set(new MaxEnduranceComponent { Value = config.MaxEndurance });
                target.Set(new EnduranceComponent { Value = config.MaxEndurance });
                target.Set(new EnduranceRecoveryComponent { Value = config.EnduranceRecovery });
                
                target.Set(new MaxSpeedComponent { Value = config.MaxSpeed });
                target.Set(new AccelerationComponent { Value = config.Acceleration });
                target.Set(new InertiaComponent { Value = config.Inertia });
                
                target.Set(new DashRangeComponent { Value = config.DashRange });
                target.Set(new SprintMultiplierComponent { Value = config.SprintMultiplier });
                
                target.Set(new BouncinessComponent { Value = config.Bounciness });
                target.Set(new FrictionComponent { Value = config.Friction });
                
                target.Set(new ColdResistanceComponent { Value = config.ColdResistance });
                target.Set(new HotResistanceComponent { Value = config.HotResistance });
                
                target.Set(new DamageReflectionComponent { Value = config.DamageReflection });
                target.Set(new DamageResistanceComponent { Value = config.DamageResistance });
                
                target.Set(new OxygenRequirementComponent { Value = config.OxygenRequirement });
                target.Set(new HydrogenRequirementComponent { Value = config.HydrogenRequirement });
                
                target.Set(new InfluenceComponent { Value = config.Influence });
                
                target.Set(new PassAbilityComponent { Value = config.PassAbility });
                
                target.Set(new PhysicalDamageComponent { Value = config.PhysicalDamage });
                
                target.Set(new PickingRangeComponent { Value = config.PickingRange });
            }

            cmdEntity.Destroy();
        }
    }
}
}