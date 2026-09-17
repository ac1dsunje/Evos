using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Regeneration
{
[Serializable]
public struct RegenerationComponent : IComponent, IDisableable, ITrackableChanged
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}