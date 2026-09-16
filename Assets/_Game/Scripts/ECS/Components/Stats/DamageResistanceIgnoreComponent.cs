using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct DamageResistanceIgnoreComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}