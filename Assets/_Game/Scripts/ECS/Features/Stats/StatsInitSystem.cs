using _Game.Scripts.ECS.Core;
using _Game.Scripts.ECS.Features.Attack;
using _Game.Scripts.ECS.Features.Dashing;
using _Game.Scripts.ECS.Features.Defense;
using _Game.Scripts.ECS.Features.Health;
using _Game.Scripts.ECS.Features.Hunger;
using _Game.Scripts.ECS.Features.Movement;
using _Game.Scripts.ECS.Features.Regeneration;
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
                new ExtraLivesComponent { Value = config.ExtraLives },
                new RegenerationComponent { Value = config.Regeneration }
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
                new ReflectionComponent { Value = config.Reflection },
                new ResistanceComponent { Value = config.Resistance }
            );

            entity.Set(
                new PhysicalDamageComponent { Value = config.PhysicalDamage },
                new ResistanceIgnoreComponent { Value = config.IgnoreResistance }
            );
        }
    }
}
}