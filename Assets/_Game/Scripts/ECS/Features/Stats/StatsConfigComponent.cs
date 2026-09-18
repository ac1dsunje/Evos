using _Game.Scripts.Configs;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Stats
{
public struct StatsConfigComponent : IComponent, ITrackableAdded
{
    public StatsConfig Config;
}
}