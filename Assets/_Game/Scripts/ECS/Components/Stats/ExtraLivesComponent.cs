using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Stats
{
public struct ExtraLivesComponent : IComponent, ITrackableChanged
{
    public float Value;
}
}