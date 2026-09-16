using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using _Game.Scripts.ECS.Events;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems.Health
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

            ref var health = ref target.Ref<HealthComponent>();
            ref var maxHealth= ref target.Ref<MaxHealthComponent>();
            ref var extraLives = ref target.Ref<ExtraLivesComponent>();
            ref var resistance = ref target.Ref<DamageResistanceComponent>();
            
            health.Value -= e.Value.Damage * (1 - (resistance.Value - e.Value.IgnoreResistance) / 100f);
            
            if (health.Value <= 0)
            {
                if (extraLives.Value > 0)
                {
                    health.Value = maxHealth.Value;
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