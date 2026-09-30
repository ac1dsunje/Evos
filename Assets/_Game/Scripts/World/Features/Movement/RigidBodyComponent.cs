using System;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Features.Movement
{
[Serializable]
public struct RigidBodyComponent : IComponent
{
    public Rigidbody2D Body;
}
}