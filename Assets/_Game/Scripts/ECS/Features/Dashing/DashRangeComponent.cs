using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Dashing
{
[Serializable]
[StaticEcsEditorName("DashRange")]
public struct DashRangeComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}