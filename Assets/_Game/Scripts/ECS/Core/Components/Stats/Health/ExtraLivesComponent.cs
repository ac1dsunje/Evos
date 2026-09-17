using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Core.Components.Stats.Health
{
[Serializable]
public struct ExtraLivesComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}