using _Game.Scripts.ECS.Components.Stats.Attack;
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
            if (!e.Value.Source.TryUnpack<GameWorld>(out var source))
                continue;
            
            if (!e.Value.Other.TryUnpack<GameWorld>(out var other))
                continue;
            
            if (!source.Has<PhysicalDamageComponent>())
                continue;

            ref readonly var damage = ref source.Read<PhysicalDamageComponent>();
            
            var ignoreResistance = 0f;
            if (source.Has<DamageResistanceIgnoreComponent>())
            {
                ignoreResistance = source.Read<DamageResistanceIgnoreComponent>().Value;
            }

            W.SendEvent(new DamageEvent
            {
                Target = other.GID,
                Damage = damage.Value,
                IgnoreResistance = ignoreResistance
            });
        }
    }
}
}