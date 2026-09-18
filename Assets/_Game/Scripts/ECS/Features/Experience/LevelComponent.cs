using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Experience
{
[Serializable]
[StaticEcsEditorName("Level")]
public struct LevelComponent : IComponent, ITrackableChanged
{
    [StaticEcsEditorTableValue(180f)] public int Value;
}
}