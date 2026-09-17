using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Components.Stats.Defense
{
[Serializable]
public struct DamageResistanceComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}