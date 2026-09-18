using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Endurance
{
[Serializable]
[StaticEcsEditorName("EnduranceRecovery")]
public struct EnduranceRecoveryComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}