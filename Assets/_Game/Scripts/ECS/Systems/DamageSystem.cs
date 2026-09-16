using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using _Game.Scripts.ECS.Events;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems
{
public struct DamageSystem : ISystem
{
    private EventReceiver<GameWorld, DamageEvent> _receiver;

    public void Init()
    {
        _receiver = W.RegisterEventReceiver<DamageEvent>();
    }

    public void Update()
    {
        foreach (var e in _receiver)
        {
            if (!e.Value.Target.TryUnpack<GameWorld>(out var target))
                continue;

            ref var healthComp = ref target.Ref<HealthComponent>();
            ref var maxHealthComp = ref target.Ref<MaxHealthComponent>();
            ref var extraLives = ref target.Ref<ExtraLivesComponent>();
            
            healthComp.Value -= e.Value.Damage;
            
            if (healthComp.Value <= 0)
            {
                if (extraLives.Value > 0)
                {
                    healthComp.Value = maxHealthComp.Value;
                    extraLives.Value--;
                }
                else
                {
                    W.SendEvent(new DeathEvent { Entity = target.GID });
                }
            }
        }
    }
}
}