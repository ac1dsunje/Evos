using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Core.Components.Stats.Health
{
[Serializable]
public struct MaxHealthComponent : IComponent, ITrackableChanged
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}