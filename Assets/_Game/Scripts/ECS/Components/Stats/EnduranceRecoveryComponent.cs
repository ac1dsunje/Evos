using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct EnduranceRecoveryComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}