using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.World.Components
{
[Serializable]
public struct PositionComponent : IComponent
{
    [StaticEcsEditorTableValue] public Vector2 Position;
}
}
