using System.Collections.Generic;
using _Game.Scripts.World.Configuration;
using _Game.Scripts.World.Features.Core;
using _Game.Scripts.World.Features.Health;
using _Game.Scripts.World.Features.InputManagement;
using _Game.Scripts.World.Features.Movement;
using _Game.Scripts.World.Features.Spawn;
using _Game.Scripts.World.Features.Stats;
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
                new HealthComponent(),
                new RegenerationComponent(),
                new InputComponent { Direction = Vector2.right },
                new MovementComponent(),
                new PositionComponent { Position = Vector2.zero }
            )
            .Set<AddViewTag>();

        foreach (var stat in Config.Stats)
        {
            entity.Add<World<GameWorld>.Multi<StatSource>>().Add(new StatSource { Stats = new List<Stat> { stat } });
        }
    }

    public void OnDestroy<TWorld>(World<TWorld>.Entity entity, HookReason reason) where TWorld : struct, IWorldType
    {
        if (!entity.Has<ViewComponent>()) return;
        ref readonly var viewComponent = ref entity.Read<ViewComponent>();
        W.GetResource<ViewPoolResource>().Release(EntityType.Creature, viewComponent.View);
    }
}
}
