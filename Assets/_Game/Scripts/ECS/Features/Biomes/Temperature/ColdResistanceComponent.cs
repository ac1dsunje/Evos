using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Biomes.Temperature
{
[Serializable]
[StaticEcsEditorName("ColdResistance")]
public struct ColdResistanceComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}