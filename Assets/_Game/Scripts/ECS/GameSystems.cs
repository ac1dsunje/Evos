using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS
{
public struct GameSystems : ISystemsType { }
public struct FixedSystems : ISystemsType { }
public abstract class GameSys : W.Systems<GameSystems> { }
public abstract class FixedSys : W.Systems<FixedSystems> { }
}