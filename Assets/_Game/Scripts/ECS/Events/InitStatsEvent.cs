using _Game.Scripts.Configs;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Events
{
public struct InitStatsEvent : IEvent
{
    public EntityGID Target;
    public EntityConfig Config;
}
}