using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Components.Requests
{
public struct CollisionRequest : IComponent
{
    public World<GameWorld>.Entity Attacker;
    public World<GameWorld>.Entity Target;
}
}