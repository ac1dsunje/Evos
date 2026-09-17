using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.ECS.Components
{
public struct PositionComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public Vector3 Position;
}
}