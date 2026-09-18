using System;
using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Core.EntityTypes;
using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Config;
using _Game.Scripts.ECS.Features.Experience;
using _Game.Scripts.ECS.Features.Input.AI;
using _Game.Scripts.ECS.Features.Input.Player;
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
        
        view.Renderer.sprite = config.Sprite;
        
        view.transform.position = position;
        view.EntityGid = creature.GID;
        
        creature.Set(
            new CreatureViewComponent { View = view },
            new RigidBodyComponent { Body = body }
            );
        
        return creature.GID;
    }
}
}