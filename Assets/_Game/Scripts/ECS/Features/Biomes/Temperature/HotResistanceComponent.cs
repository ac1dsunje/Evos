using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Biomes.Temperature
{
[Serializable]
[StaticEcsEditorName("HotResistance")]
public struct HotResistanceComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}