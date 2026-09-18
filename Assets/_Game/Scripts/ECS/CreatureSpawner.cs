using System;
using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Core.EntityTypes;
using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Experience;
using _Game.Scripts.ECS.Features.Input.AI;
using _Game.Scripts.ECS.Features.Input.Player;
using _Game.Scripts.ECS.Features.Stats;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class CreatureSpawner
{
    public EntityGID SpawnCreature(Rigidbody2D rigidBody, EntityView view, CreatureConfig config)
    {
        var creature = W.NewEntity<Creature>().Set(
            new RigidBodyComponent { Body = rigidBody },
            new CreatureViewComponent { View = view },
            new ExperienceComponent { Set = config.Experience.Set });
        switch (config.Input)
        {
            case CreatureInput.AI:
                creature.Set<AIControlledTag>();
                creature.Set(new AIThinkTimerComponent { Interval = 1f });
                break;
            case CreatureInput.Player:
                creature.Set<PlayerControlledTag>();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        W.SendEvent(new InitStatsEvent
        {
            Target = creature.GID,
            Config = config
        });
        
        return creature.GID;
    }
}
}