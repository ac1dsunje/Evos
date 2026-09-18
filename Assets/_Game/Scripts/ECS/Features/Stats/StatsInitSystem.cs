using _Game.Scripts.ECS.Features.Attack;
using _Game.Scripts.ECS.Features.Biomes;
using _Game.Scripts.ECS.Features.Biomes.Breathing;
using _Game.Scripts.ECS.Features.Biomes.Temperature;
using _Game.Scripts.ECS.Features.Defense;
using _Game.Scripts.ECS.Features.Endurance;
using _Game.Scripts.ECS.Features.Health;
using _Game.Scripts.ECS.Features.Hunger;
using _Game.Scripts.ECS.Features.Movement;
using _Game.Scripts.ECS.Features.Picking;
using _Game.Scripts.ECS.Features.Regeneration;
using _Game.Scripts.ECS.Features.Social;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Stats
{
public struct StatsInitSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<AllAdded<StatsConfigComponent>>().Entities())
        {
            ref readonly var config = ref entity.Read<StatsConfigComponent>().Config;
            
            entity.Set(
                new MaxHealthComponent { Value = config.MaxHealth },
                new HealthComponent { Value = config.MaxHealth }
                );
            
            entity.Set(
                new MaxHungerComponent { Value = config.MaxHunger },
                new HungerComponent { Value = config.MaxHunger }
                );
            
            entity.Set(
                new MaxEnduranceComponent { Value = config.MaxEndurance },
                new EnduranceComponent { Value = config.MaxEndurance }
                );
            
            entity.Set(
                new ExtraLivesComponent { Value = config.ExtraLives },
                new RegenerationComponent { Value = config.Regeneration },
                new EnduranceRecoveryComponent { Value = config.EnduranceRecovery }
                );
            
            entity.Set(
                new MaxSpeedComponent { Value = config.MaxSpeed },
                new AccelerationComponent { Value = config.Acceleration },
                new InertiaComponent { Value = config.Inertia }
                );
            
            entity.Set(
                new DashRangeComponent { Value = config.DashRange },
                new SprintMultiplierComponent { Value = config.SprintMultiplier }
            );
            
            entity.Set(
                new ColdResistanceComponent { Value = config.ColdResistance },
                new HotResistanceComponent { Value = config.HotResistance }
            );
            
            entity.Set(
                new ReflectionComponent { Value = config.Reflection },
                new ResistanceComponent { Value = config.Resistance }
            );
            
            entity.Set(
                new OxygenComponent { Value = config.OxygenRequirement },
                new HydrogenComponent { Value = config.HydrogenRequirement }
            );
            
            entity.Set(new InfluenceComponent { Value = config.Influence });
            
            entity.Set(new PassAbilityComponent { Value = config.PassAbility });
            
            entity.Set(
                new PhysicalDamageComponent { Value = config.PhysicalDamage },
                new ResistanceIgnoreComponent { Value = config.IgnoreResistance }
            );
            
            entity.Set(new PickingRangeComponent { Value = config.PickingRange });
        }
    }
}
}