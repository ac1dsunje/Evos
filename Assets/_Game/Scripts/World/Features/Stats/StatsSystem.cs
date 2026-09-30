using _Game.Scripts.World.Features.Health;
using _Game.Scripts.World.Features.Movement;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Features.Stats
{
public struct StatsSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<World<GameWorld>.Multi<StatSource>>>().Entities())
        {
            var sources = entity.Read<World<GameWorld>.Multi<StatSource>>();

            float maxHealth = 0;
            float moveSpeed = 0;
            float acceleration = 0;
            float inertia = 0;
            float regeneration = 0;

            foreach (var source in sources)
            {
                foreach (var stat in source.Stats)
                {
                    switch (stat.Type)
                    {
                        case StatType.MaxHealth:
                            maxHealth += stat.Value;
                            break;
                        case StatType.MoveSpeed:
                            moveSpeed += stat.Value;
                            break;
                        case StatType.Acceleration:
                            acceleration += stat.Value;
                            break;
                        case StatType.Inertia:
                            inertia += stat.Value;
                            break;
                        case StatType.Regeneration:
                            regeneration += stat.Value;
                            break;
                    }
                }
            }

            ref var health = ref entity.Ref<HealthComponent>();
            health.Max = maxHealth;
            health.Current = Mathf.Min(health.Current, maxHealth);
            
            ref var regen = ref entity.Ref<RegenerationComponent>();
            regen.Value = regeneration;
            
            ref var movement = ref entity.Ref<MovementComponent>();
            movement.MaxSpeed = moveSpeed;
            movement.Acceleration = acceleration;
            movement.Inertia = inertia;
        }
    }
}
}
