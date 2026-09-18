using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Core
{
public struct Systems : ISystemsType { }
public struct FixedSystems : ISystemsType { }
public abstract class GameSys : W.Systems<Systems> { }
public abstract class FixedSys : W.Systems<FixedSystems> { }
}