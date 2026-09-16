using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct SprintMultiplierComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}