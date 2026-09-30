using _Game.Scripts.World.Entities;
using _Game.Scripts.World.Features.InputManagement;
using _Game.Scripts.World.Features.Movement;
using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Systems
{
public struct PlayerSpawnSystem : ISystem
{
    public void Init()
    {
        var entity = W.NewEntity(new Creature
        {
            Config = W.GetResource<CreatureConfigsResource>().PlayerConfig
        });
        
        entity.Set<PlayerInputTag>();

        ref var position = ref entity.Ref<PositionComponent>();
        position.Position = Vector2.zero;
    }
}
}
