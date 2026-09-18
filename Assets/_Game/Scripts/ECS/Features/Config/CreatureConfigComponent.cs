using System;
using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Features.Stats;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Config
{
[Serializable]
[StaticEcsEditorName("CreatureConfig")]
public struct CreatureConfigComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public CreatureConfig Config;

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