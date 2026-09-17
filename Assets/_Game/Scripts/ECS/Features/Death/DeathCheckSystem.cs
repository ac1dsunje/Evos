using _Game.Scripts.ECS.Core.Components;
using _Game.Scripts.ECS.Features.Health;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Death
{
public struct DeathCheckSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<AllChanged<HealthComponent>>().Entities())
        {
            ref var health = ref entity.Mut<HealthComponent>();
            if (health.Value > 0f) continue;

            if (entity.Has<ExtraLivesComponent>())
            {
                ref var lives = ref entity.Mut<ExtraLivesComponent>();
                if (lives.Value > 0)
                {
                    lives.Value--;
                    health.Value = entity.Read<MaxHealthComponent>().Value;
                    continue;
                }
            }

            W.SendEvent(new DeathEvent { Entity = entity.GID });
        }
    }
}
}