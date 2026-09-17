using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Core.Components.Stats
{
[Serializable]
public struct PickingRangeComponent : IComponent, ITrackableChanged
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}