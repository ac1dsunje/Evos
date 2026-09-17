using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Endurance
{
[Serializable]
public struct EnduranceComponent : IComponent, ITrackableChanged
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}