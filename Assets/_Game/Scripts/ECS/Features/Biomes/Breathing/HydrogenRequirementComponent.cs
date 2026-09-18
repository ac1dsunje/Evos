using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Biomes.Breathing
{
[Serializable]
[StaticEcsEditorName("HydrogenRequirement")]
public struct HydrogenRequirementComponent : IComponent, IDisableable, ITrackableChanged
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}