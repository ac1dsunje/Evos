using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.ECS.Core.Components
{
public struct RigidBodyComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public Rigidbody2D Body;
}
}