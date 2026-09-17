using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Components.Stats.Endurance
{
[Serializable]
public struct EnduranceRecoveryComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}