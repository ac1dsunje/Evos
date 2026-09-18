using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Movement
{
[Serializable]
[StaticEcsEditorName("Acceleration")]
[StaticEcsEditorGroup("Movement", "00FF00")]
public struct AccelerationComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}