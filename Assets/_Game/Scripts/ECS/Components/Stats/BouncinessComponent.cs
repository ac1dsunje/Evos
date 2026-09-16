using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct BouncinessComponent : IComponent, ITrackableAdded, ITrackableChanged
{
    public float Value;
}
}