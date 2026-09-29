using _Game.Scripts.World.Components;
using _Game.Scripts.World.Tags;
using _Game.Scripts.World.View;
using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Entities
{
public struct Creature : IEntityType
{
    public byte Id() => 1;
    public bool IsPlayer;

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
                },
                new PositionComponent()
            )
            .Set<AddViewTag>();

        if (IsPlayer)
        {
            entity.Set<PlayerInputTag>();
        }
        else
        {
            entity.Set<RandomInputTag>();
        }
    }

    public void OnDestroy<TWorld>(World<TWorld>.Entity entity, HookReason reason) where TWorld : struct, IWorldType
    {
        if (!entity.Has<TransformComponent>()) return;
        ref readonly var transform = ref entity.Read<TransformComponent>();
        var view = transform.Transform.GetComponent<CreatureView>();
        W.GetResource<CreatureViewPoolResource>().Pool.Release(view);
    }
}
}
