using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class EntitySpawner
{
    public void Spawn(float startHp, Vector3 startPos, float speed)
    {
        W.NewEntity<Default>().Set(
            new HealthComponent { Value = 1 },
            new MaxHealthComponent { Value = startHp },
            new PositionComponent { Position = startPos },
            new MaxSpeedComponent { Value = speed },
            new RigidBodyComponent { Body = null },
            new RegenerationComponent { Value = 1},
            new InputComponent {Direction = Vector3.zero}
    );
}
}
}