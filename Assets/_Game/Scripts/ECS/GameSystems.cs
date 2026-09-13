using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS
{
public struct GameSystems : ISystemsType { }

public abstract class GameSys : W.Systems<GameSystems> { }
}