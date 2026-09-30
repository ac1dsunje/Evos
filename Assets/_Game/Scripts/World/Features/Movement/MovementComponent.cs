using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.World.Features.Movement
{
[Serializable]
public struct MovementComponent : IComponent
{
    [StaticEcsEditorTableValue] public float MaxSpeed;
    [StaticEcsEditorTableValue] public float Acceleration;
    [StaticEcsEditorTableValue] public float Inertia;
}
}