using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Components
{
public struct RigidBodyComponent : IComponent
{
    public Rigidbody2D Body;
}
}