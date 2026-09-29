using _Game.Scripts.World.Components;
using _Game.Scripts.World.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Entities
{
public struct Creature : IEntityType
{
    public byte Id() => 1;

    public void OnCreate<TWorld>(World<TWorld>.Entity entity) where TWorld : struct, IWorldType
    {
        entity
            .Set(
                new NameComponent { Name = "Creature" },
                new HealthComponent { Value = Random.Range(1, 100) },
                new InputComponent { Direction = Vector2.right },
                new MovementComponent
                {
                    MaxSpeed = 1,
                    Acceleration = 1,
                    Inertia = 1,
                }
            )
            .Set<AddViewTag>();
    }
}
}