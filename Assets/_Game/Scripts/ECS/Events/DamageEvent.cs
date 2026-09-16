using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Events
{
public struct DamageEvent : IEvent
{
    public EntityGID Target;
    public float Damage;
    public float IgnoreResistance;
}
}