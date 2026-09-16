using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct MaxSpeedComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}