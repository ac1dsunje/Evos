using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components
{
public struct HealthComponent : IComponent
{
    public float Current;
    public float Max;
}
}