using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Core.Components.Stats.Movement
{
[Serializable]
public struct AccelerationComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}