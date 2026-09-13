using _Game.Scripts.ECS.Components;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class EntitySpawner
{
    public void Spawn(float startHp)
    {
        var entity = W.NewEntity<Default>().Set(
            new HealthComponent { Current = startHp, Max = startHp }
        );

        Debug.Log($"Создана сущность ID: {entity.ID} с HP: {startHp}");
    }
}
}