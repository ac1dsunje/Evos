using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.World.Features.Health
{
[Serializable]
public struct HealthComponent : IComponent
{
    [StaticEcsEditorTableValue] public float Current;
    [StaticEcsEditorTableValue] public float Max;
}
}