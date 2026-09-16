using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct FrictionComponent : IComponent, ITrackableAdded, ITrackableChanged
{
    public float Value;
}
}