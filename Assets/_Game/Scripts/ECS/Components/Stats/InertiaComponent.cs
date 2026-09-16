using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct InertiaComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}