using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Components.Stats.Attack
{
[Serializable]
public struct PhysicalDamageComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}