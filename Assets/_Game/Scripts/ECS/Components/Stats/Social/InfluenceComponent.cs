using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Components.Stats.Social
{
[Serializable]
public struct InfluenceComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}