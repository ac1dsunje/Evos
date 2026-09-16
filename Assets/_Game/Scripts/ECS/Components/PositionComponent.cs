using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Components
{
public struct PositionComponent : IComponent, ITrackableChanged
{
    public Vector3 Position;
}
}