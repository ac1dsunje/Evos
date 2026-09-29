using _Game.Scripts.World.Entities;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World.Systems
{
public struct SpawnerSystem : ISystem
{
    public void Update()
    {
        var count = W.CalculateEntitiesCount();
        if (count < 5)
        {
            W.NewEntity(new Creature {IsPlayer = count < 1});
        }
    }
}
}