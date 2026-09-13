using _Game.Scripts.ECS.Components;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS
{
public class EntitySpawner
{
    public void Spawn(float startHp)
    {
        W.NewEntity<Default>().Set(
            new HealthComponent { Current = startHp, Max = startHp }
        );
    }
}
}