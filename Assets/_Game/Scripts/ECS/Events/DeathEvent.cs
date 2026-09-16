using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Events
{
public struct DeathEvent : IEvent
{
    public EntityGID Entity;
}
}