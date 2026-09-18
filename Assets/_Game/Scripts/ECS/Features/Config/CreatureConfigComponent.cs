using System;
using _Game.Scripts.Configs;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Config
{
[Serializable]
[StaticEcsEditorName("CreatureConfig")]
public struct CreatureConfigComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public CreatureConfig Config;
}
}