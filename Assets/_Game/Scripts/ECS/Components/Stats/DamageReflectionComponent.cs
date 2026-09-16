using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct DamageReflectionComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}