using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Dashing
{
[Serializable]
[StaticEcsEditorName("DashRange")]
[StaticEcsEditorGroup("Movement", "00FF00")]
public struct DashRangeComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}