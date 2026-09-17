using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Body
{
public struct RigidBodyComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public Rigidbody2D Body;
}
}