using _Game.Scripts.ECS.Core.Components;
using _Game.Scripts.ECS.Core.Components.Stats;
using _Game.Scripts.ECS.Core.Components.Stats.Attack;
using _Game.Scripts.ECS.Core.Components.Stats.Defense;
using _Game.Scripts.ECS.Core.Components.Stats.Health;
using _Game.Scripts.ECS.Core.Components.Stats.Movement;
using _Game.Scripts.ECS.Features.Breathing;
using _Game.Scripts.ECS.Features.Endurance;
using _Game.Scripts.ECS.Features.Hunger;
using _Game.Scripts.ECS.Features.Regeneration;
using _Game.Scripts.ECS.Features.Social;
using _Game.Scripts.ECS.Features.Stats;
using _Game.Scripts.ECS.Features.Temperature;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Core.Systems
{
public struct StatsInitSystem : ISystem
{
    private EventReceiver<GameWorld, InitStatsEvent> _receiver;

    public void Init()
    {
        _receiver = W.RegisterEventReceiver<InitStatsEvent>();
    }

    public void Update()
    {
        foreach (var e in _receiver)
        {
            if (!e.Value.Target.TryUnpack<GameWorld>(out var target))
                continue;
            
            var config = e.Value.Config;
            
            target.Set(new MaxHealthComponent { Value = config.MaxHealth });
            target.Set(new HealthComponent { Value = config.MaxHealth });
            
            target.Set(new MaxHungerComponent { Value = config.MaxHunger });
            target.Set(new HungerComponent { Value = config.MaxHunger });
            
            target.Set(new MaxEnduranceComponent { Value = config.MaxEndurance });
            target.Set(new EnduranceComponent { Value = config.MaxEndurance });
            
            target.Set(new ExtraLivesComponent { Value = config.ExtraLives });
            target.Set(new RegenerationComponent { Value = config.Regeneration });
            target.Set(new EnduranceRecoveryComponent { Value = config.EnduranceRecovery });
            
            target.Set(new MaxSpeedComponent { Value = config.MaxSpeed });
            target.Set(new AccelerationComponent { Value = config.Acceleration });
            target.Set(new InertiaComponent { Value = config.Inertia });
            
            target.Set(new DashRangeComponent { Value = config.DashRange });
            target.Set(new SprintMultiplierComponent { Value = config.SprintMultiplier });
            
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
            
            target.Set(new DamageResistanceIgnoreComponent { Value = config.DamageResistance });
        }
    }
}
}