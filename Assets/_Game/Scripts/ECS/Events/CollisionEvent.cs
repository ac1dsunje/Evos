using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Events
{
public struct CollisionEvent : IEvent
{
    public EntityGID Attacker;
    public EntityGID Target;
}
}