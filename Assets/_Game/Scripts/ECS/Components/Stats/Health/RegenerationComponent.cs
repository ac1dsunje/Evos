using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Components.Stats.Health
{
[Serializable]
public struct RegenerationComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}