using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.Components
{
// 1. Маркер типа мира (может быть struct или class)
public struct GameWorld : IWorldType { }

// 2. Алиас для удобного доступа ко всем методам мира (как в документации)
// Теперь вместо длинных конструкций мы будем использовать короткое "W"
public abstract class W : World<GameWorld> { }

// 3. Компонент. В StaticECS компоненты всегда реализуют IComponent
public struct HealthComponent : IComponent
{
    public float Current;
    public float Max;
}
}