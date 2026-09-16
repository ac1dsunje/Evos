using _Game.Scripts.Configs;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Requests
{
public struct InitStatsRequest : IComponent
{
    public World<GameWorld>.Entity Target;
    public EntityConfig Config;
}
}