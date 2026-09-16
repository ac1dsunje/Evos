using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct DashRangeComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}