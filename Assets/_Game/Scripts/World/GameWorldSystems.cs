using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World
{
public struct GameSystems : ISystemsType { }
public struct InputSystems : ISystemsType { }
public struct FixedSystems : ISystemsType { }
public abstract class GameSys : W.Systems<GameSystems> { }
public abstract class InputSys : W.Systems<InputSystems> { }
public abstract class FixedSys : W.Systems<FixedSystems> { }
}