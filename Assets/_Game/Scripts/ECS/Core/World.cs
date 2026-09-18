using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Core
{
public struct GameWorld : IWorldType { }

public abstract class W : World<GameWorld> { }
}