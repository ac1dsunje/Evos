using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.ECS.Components
{
public struct InputComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public Vector2 Direction;
}
}