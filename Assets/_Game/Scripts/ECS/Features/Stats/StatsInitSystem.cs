using _Game.Scripts.ECS.Core.Components;
using _Game.Scripts.ECS.Features.Attack;
using _Game.Scripts.ECS.Features.Biomes;
using _Game.Scripts.ECS.Features.Biomes.Breathing;
using _Game.Scripts.ECS.Features.Biomes.Temperature;
using _Game.Scripts.ECS.Features.Defense;
using _Game.Scripts.ECS.Features.Endurance;
using _Game.Scripts.ECS.Features.Health;
using _Game.Scripts.ECS.Features.Hunger;
using _Game.Scripts.ECS.Features.Movement;
using _Game.Scripts.ECS.Features.Regeneration;
using _Game.Scripts.ECS.Features.Social;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Stats
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
            
            var config = e.Value.Config.Stats;
            
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
            
            target.Set(new ReflectionComponent { Value = config.Reflection });
            target.Set(new ResistanceComponent { Value = config.Resistance });
            
            target.Set(new OxygenRequirementComponent { Value = config.OxygenRequirement });
            target.Set(new HydrogenRequirementComponent { Value = config.HydrogenRequirement });
            
            target.Set(new InfluenceComponent { Value = config.Influence });
            
            target.Set(new PassAbilityComponent { Value = config.PassAbility });
            
            target.Set(new PhysicalDamageComponent { Value = config.PhysicalDamage });
            target.Set(new ResistanceIgnoreComponent { Value = config.IgnoreResistance });
            
            target.Set(new PickingRangeComponent { Value = config.PickingRange });
        }
    }
}
}