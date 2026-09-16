using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct OxygenRequirementComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}