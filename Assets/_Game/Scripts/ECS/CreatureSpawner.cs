using System;
using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Core.EntityTypes;
using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Config;
using _Game.Scripts.ECS.Features.Experience;
using _Game.Scripts.ECS.Features.Input.AI;
using _Game.Scripts.ECS.Features.Input.Player;
using _Game.Scripts.ECS.Features.Stats;
using FFS.Libraries.StaticEcs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Scripts.ECS
{
public class CreatureSpawner
{
    public EntityGID SpawnCreature(CreatureConfig config, Vector2 position, Transform container)
    {
        var creature = W.NewEntity<Creature>().Set(
            new CreatureConfigComponent { Config = config },
            new ExperienceComponent { Set = config.Experience.Set });

        var prefab = W.GetResource<EntityView>("Creature_prefab");
        var view = Object.Instantiate(prefab, container);
        var body = view.Body;
        var render = view.Renderer;
        
        render.sprite = config.Sprite;
        view.transform.position = position;
        view.EntityGid = creature.GID;
        
        creature.Set(new CreatureViewComponent { View = view });
        creature.Set(new RigidBodyComponent { Body = body });

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