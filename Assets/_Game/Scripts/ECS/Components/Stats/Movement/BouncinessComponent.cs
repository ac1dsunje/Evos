using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats.Movement
{
public struct BouncinessComponent : IComponent, ITrackableAdded, ITrackableChanged
{
    public float Value;
}
}