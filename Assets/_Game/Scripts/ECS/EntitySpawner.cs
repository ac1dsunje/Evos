using _Game.Scripts.ECS.Components;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class EntitySpawner
{
    public void Spawn(float startHp, Vector3 startPos, float speed)
    {
        W.NewEntity<Default>().Set(
            new HealthComponent { Current = 1, Max = startHp },
            new PositionComponent { Position = startPos },
            new SpeedComponent { Speed = speed },
            new RigidBodyComponent { Body = null },
            new RegenerationComponent { Regeneration = 1},
            new InputComponent {Input = Vector3.zero}
    );
}
}
}