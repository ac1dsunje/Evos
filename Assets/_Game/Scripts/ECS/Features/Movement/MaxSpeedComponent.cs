using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Movement
{
[Serializable]
[StaticEcsEditorName("MaxSpeed")]
public struct MaxSpeedComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}