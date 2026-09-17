using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Core.Components.Attack
{
[Serializable]
public struct DamageResistanceIgnoreComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}