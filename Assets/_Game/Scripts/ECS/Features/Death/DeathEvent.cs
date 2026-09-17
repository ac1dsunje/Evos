using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Death
{
public struct DeathEvent : IEvent
{
    public EntityGID Entity;
}
}