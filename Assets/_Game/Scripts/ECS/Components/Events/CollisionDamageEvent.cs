using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Events
{
public struct CollisionDamageEvent : IComponent
{
    public World<GameWorld>.Entity Attacker;
    public World<GameWorld>.Entity Target;
}
}