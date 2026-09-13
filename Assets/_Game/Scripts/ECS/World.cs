using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS
{
public struct GameWorld : IWorldType { }

public abstract class W : World<GameWorld> { }
}