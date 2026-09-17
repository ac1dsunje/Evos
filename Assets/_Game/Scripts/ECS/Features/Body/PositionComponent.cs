using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Body
{
public struct PositionComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public Vector3 Position;
}
}