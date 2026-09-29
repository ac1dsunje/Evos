using System.Collections.Generic;
using _Game.Scripts.World.Entities;
using _Game.Scripts.World.Pool;
using _Game.Scripts.World.View;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World.WorldResources
{
public struct ViewPoolResource : IResource
{
    public Dictionary<EntityType, ObjectPool<EntityView>> Pools;

    public readonly EntityView Get(EntityType type)
    {
        return Pools[type].Get();
    }

    public readonly void Release(EntityType type, EntityView view)
    {
        Pools[type].Release(view);
    }
}
}
