using _Game.Scripts.World.Pool;
using _Game.Scripts.World.View;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World.WorldResources
{
public struct CreatureViewPoolResource : IResource
{
    public ObjectPool<CreatureView> Pool;
}
}
