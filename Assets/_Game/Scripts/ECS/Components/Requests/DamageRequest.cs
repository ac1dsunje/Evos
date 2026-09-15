using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Requests
{
public struct DamageRequest : IComponent
{
    public World<GameWorld>.Entity Target;
    public float Damage;
}
}