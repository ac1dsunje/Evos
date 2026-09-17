using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Defense
{
[Serializable]
public struct ReflectionComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public float Value;
}
}