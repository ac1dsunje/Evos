using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct MaxHealthComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}