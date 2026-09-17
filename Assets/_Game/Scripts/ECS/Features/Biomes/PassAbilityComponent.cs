using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Biomes
{
[Serializable]
public struct PassAbilityComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}