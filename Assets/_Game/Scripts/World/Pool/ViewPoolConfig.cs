using System;
using _Game.Scripts.World.Entities;
using _Game.Scripts.World.View;

namespace _Game.Scripts.World.Pool
{
[Serializable]
public struct ViewPoolConfig
{
    public EntityType EntityType;
    public EntityView Prefab;
    public int PrewarmCount;
}
}