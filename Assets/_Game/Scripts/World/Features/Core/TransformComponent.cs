using System;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Features.Core
{
[Serializable]
public struct TransformComponent : IComponent
{
    public Transform Transform;
}
}