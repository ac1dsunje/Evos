using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Core.Components;
using _Game.Scripts.ECS.Core.Events;
using _Game.Scripts.ECS.Core.Tags;
using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Stats;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class EntitySpawner
{
    public EntityGID SpawnPlayer(Vector2 position, Rigidbody2D rigidBody, EntityView view, EntityConfig config)
    {
        var entity = CreateBaseEntity(position, rigidBody, view, config);
        entity.Set<PlayerControlledTag>();
        return entity.GID;
    }
    
    public EntityGID SpawnEnemy(Vector2 position, Rigidbody2D rigidBody, EntityView view, EntityConfig config)
    {
        var entity = CreateBaseEntity(position, rigidBody, view, config);
        entity.Set<AIControlledTag>();
        return entity.GID;
    }
    
    private World<GameWorld>.Entity CreateBaseEntity(Vector2 position, Rigidbody2D rigidBody, EntityView view, EntityConfig config)
    {
        var entity = W.NewEntity<Default>().Set(
            new PositionComponent { Position = position },
            new InputComponent { Direction = Vector2.zero },
            new RigidBodyComponent { Body = rigidBody },
            new ViewComponent { View = view }
        );
        
        W.SendEvent(new InitStatsEvent
        {
            Target = entity.GID,
            Config = config
        });
        
        return entity;
    }
}
}