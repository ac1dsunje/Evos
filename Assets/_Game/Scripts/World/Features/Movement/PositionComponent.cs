using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.World.Features.Movement
{
[Serializable]
public struct PositionComponent : IComponent
{
    [StaticEcsEditorTableValue] public Vector2 Position;
}
}
