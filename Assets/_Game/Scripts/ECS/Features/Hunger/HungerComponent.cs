using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Hunger
{
[Serializable]
public struct HungerComponent : IComponent, ITrackableChanged
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}