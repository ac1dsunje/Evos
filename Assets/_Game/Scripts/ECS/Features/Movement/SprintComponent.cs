using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Movement
{
[Serializable]
[StaticEcsEditorName("SprintMultiplier")]
[StaticEcsEditorGroup("Movement", "00FF00")]
public struct SprintMultiplierComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}