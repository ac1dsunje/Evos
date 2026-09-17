using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Core.Components.Stats.Breathing
{
[Serializable]
public struct OxygenRequirementComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}