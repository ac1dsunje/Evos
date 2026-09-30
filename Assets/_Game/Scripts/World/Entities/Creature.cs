using _Game.Scripts.World.Components;
using _Game.Scripts.World.Configuration;
using _Game.Scripts.World.Tags;
using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Entities
{
public struct Creature : IEntityType
{
    public byte Id() => 1;
    public CreatureConfig Config;

    public void OnCreate<TWorld>(World<TWorld>.Entity entity) where TWorld : struct, IWorldType
    {
        entity
            .Set(
                new NameComponent { Name = Config.Name },
                new HealthComponent { Current = Config.MaxHealth, Max = Config.MaxHealth },
                new InputComponent { Direction = Vector2.right },
                new MovementComponent
                {
                    MaxSpeed = Config.Speed,
                    Acceleration = 1,
                    Inertia = 1,
                },
                new PositionComponent()
            )
            .Set<AddViewTag>();
    }

    public void OnDestroy<TWorld>(World<TWorld>.Entity entity, HookReason reason) where TWorld : struct, IWorldType
    {
        if (!entity.Has<ViewComponent>()) return;
        ref readonly var viewComponent = ref entity.Read<ViewComponent>();
        W.GetResource<ViewPoolResource>().Release(EntityType.Creature, viewComponent.View);
    }
}
}
