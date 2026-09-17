using _Game.Scripts.ECS.Core.Components.Attack;
using _Game.Scripts.ECS.Core.Events;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Collisions
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
            if (!e.Value.Source.TryUnpack<GameWorld>(out var source))
                continue;
            
            if (!e.Value.Other.TryUnpack<GameWorld>(out var other))
                continue;
            
            if (!source.Has<PhysicalDamageComponent>())
                continue;

            ref readonly var damage = ref source.Read<PhysicalDamageComponent>();
            if (damage.Value <= 0f) continue;

            var ignoreRes = source.Has<DamageResistanceIgnoreComponent>()
                ? source.Read<DamageResistanceIgnoreComponent>().Value
                : 0f;

            W.SendEvent(new DamageEvent
            {
                Source = source.GID,
                Target = other.GID,
                Damage = damage.Value,
                IgnoreResistance = ignoreRes
            });
        }
    }
}
}