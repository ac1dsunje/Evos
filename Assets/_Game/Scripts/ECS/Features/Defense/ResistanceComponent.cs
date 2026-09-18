using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Defense
{
[Serializable]
[StaticEcsEditorName("Resistance")]
public struct ResistanceComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}