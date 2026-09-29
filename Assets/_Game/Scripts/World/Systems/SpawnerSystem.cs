using _Game.Scripts.World.Entities;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World.Systems
{
public struct SpawnerSystem : ISystem
{
    public void Update()
    {
        if (W.CalculateEntitiesCount() < 5)
        {
            W.NewEntity<Creature>();
        }
    }
}
}