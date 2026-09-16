using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components
{
public struct EnduranceComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}