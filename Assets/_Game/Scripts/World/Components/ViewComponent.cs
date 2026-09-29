using System;
using _Game.Scripts.World.View;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World.Components
{
[Serializable]
public struct ViewComponent : IComponent
{
    public EntityView View;
}
}
