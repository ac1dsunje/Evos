using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Breathing
{
[Serializable]
public struct HydrogenRequirementComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}