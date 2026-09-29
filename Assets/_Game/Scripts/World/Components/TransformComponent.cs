using System;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Components
{
[Serializable]
public struct TransformComponent : IComponent
{
    public Transform Transform;
}
}