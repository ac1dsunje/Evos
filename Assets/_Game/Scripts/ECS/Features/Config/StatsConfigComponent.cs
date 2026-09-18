using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Features.Stats;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Config
{
public struct StatsConfigComponent : IComponent
{
    public StatsConfig Config;

    public void OnAdd<TWorld>(World<TWorld>.Entity self) where TWorld : struct, IWorldType
    {
        W.SendEvent(new InitStatsEvent
        {
            Target = self.GID,
            Config = Config
        });
    }
}
}