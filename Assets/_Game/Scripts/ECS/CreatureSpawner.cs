using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Experience;
using _Game.Scripts.ECS.Features.Input;
using _Game.Scripts.ECS.Features.Stats;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class CreatureSpawner
{
    public EntityGID SpawnPlayer(Vector2 position, Rigidbody2D rigidBody, EntityView view, EntityConfig config)
    {
        var creature = CreateBaseCreature(position, rigidBody, view, config);
        creature.Set<PlayerControlledTag>();
        return creature.GID;
    }
    
    public EntityGID SpawnEnemy(Vector2 position, Rigidbody2D rigidBody, EntityView view, EntityConfig config)
    {
        var creature = CreateBaseCreature(position, rigidBody, view, config);
        creature.Set<AIControlledTag>();
        return creature.GID;
    }
    
    private World<GameWorld>.Entity CreateBaseCreature(Vector2 position, Rigidbody2D rigidBody, EntityView view, EntityConfig config)
    {
        var creature = W.NewEntity<Default>().Set(
            new PositionComponent { Position = position },
            new InputComponent { Direction = Vector2.zero },
            new RigidBodyComponent { Body = rigidBody },
            new ViewComponent { View = view },
            new ExperienceComponent { Value = 0, Set = 5 },
            new LevelComponent { Value = 0 }
        );
        
        W.SendEvent(new InitStatsEvent
        {
            Target = creature.GID,
            Config = config
        });
        
        return creature;
    }
}
}