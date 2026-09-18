using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Attack
{
[Serializable]
[StaticEcsEditorName("PhysicalDamage")]
public struct PhysicalDamageComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}