using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Core.Events
{
public struct DeathEvent : IEvent
{
    public EntityGID Entity;
}
}