using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.Components
{
public struct GameWorld : IWorldType { }

public abstract class W : World<GameWorld> { }

public struct GameSystems : ISystemsType { }

public abstract class GameSys : W.Systems<GameSystems> { }

public struct HealthComponent : IComponent
{
    public float Current;
    public float Max;
}
}