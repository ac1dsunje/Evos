using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components
{
public struct HungerComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}