using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Events
{
public struct CollisionEvent : IEvent
{
    public EntityGID Source;
    public EntityGID Other;
}
}