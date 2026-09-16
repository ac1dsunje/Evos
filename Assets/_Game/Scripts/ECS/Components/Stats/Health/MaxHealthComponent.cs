using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats.Health
{
public struct MaxHealthComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}