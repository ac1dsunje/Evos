using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct PhysicalDamageComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}