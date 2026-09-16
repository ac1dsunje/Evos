using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats.Endurance
{
public struct MaxEnduranceComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}