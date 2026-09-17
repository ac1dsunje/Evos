using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Collisions
{
public struct CollisionEvent : IEvent
{
    public EntityGID Source;
    public EntityGID Other;
}
}