using _Game.Scripts.ECS.Components.Stats;
using _Game.Scripts.ECS.Events;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems
{
public struct CollisionDamageSystem : ISystem
{
    private EventReceiver<GameWorld, CollisionEvent> _receiver;

    public void Init()
    {
        _receiver = W.RegisterEventReceiver<CollisionEvent>();
    }

    public void Update()
    {
        foreach (var e in _receiver)
        {
            if (!e.Value.Source.TryUnpack<GameWorld>(out var attacker))
                continue;

            if (!e.Value.Other.TryUnpack<GameWorld>(out var target))
                continue;

            if (!attacker.Has<PhysicalDamageComponent>())
                continue;

            ref var damageComp = ref attacker.Ref<PhysicalDamageComponent>();

            W.SendEvent(new DamageEvent
            {
                Target = target.GID,
                Damage = damageComp.Value
            });
        }
    }
}
}