using System;
using _Game.Scripts.World.View;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World.Features.Spawn
{
[Serializable]
public struct ViewComponent : IComponent
{
    public EntityView View;
}
}
