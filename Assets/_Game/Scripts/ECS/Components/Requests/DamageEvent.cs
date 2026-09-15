using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Requests
{
public struct DamageEvent : IComponent
{
    public World<GameWorld>.Entity Target;
    public float Damage;
}
}