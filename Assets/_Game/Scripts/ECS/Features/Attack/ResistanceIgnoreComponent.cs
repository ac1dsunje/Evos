using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Attack
{
[Serializable]
[StaticEcsEditorName("ResistanceIgnore")]
public struct ResistanceIgnoreComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}