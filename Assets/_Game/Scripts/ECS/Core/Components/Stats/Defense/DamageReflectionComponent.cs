using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Core.Components.Stats.Defense
{
[Serializable]
public struct DamageReflectionComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}