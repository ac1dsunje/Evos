using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Body
{
[Serializable]
[StaticEcsEditorName("Position")]
public struct PositionComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public Vector2 Position;
}
}