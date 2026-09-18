using _Game.Scripts.Configs;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Stats
{
public struct InitStatsEvent : IEvent
{
    public EntityGID Target;
    public StatsConfig Config;
}
}