using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components
{
public struct HealthComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}