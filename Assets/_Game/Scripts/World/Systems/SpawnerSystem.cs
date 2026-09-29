using _Game.Scripts.World.Components;
using _Game.Scripts.World.Entities;
using _Game.Scripts.World.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Systems
{
public struct SpawnerSystem : ISystem
{
    private const int MaxCreatures = 25;
    private const float SpawnRadius = 10f;
    
    public void Update()
    {
        var count = W.CalculateEntitiesCount();
        if (count >= MaxCreatures) return;

        var isPlayer = count < 1;
        var spawnPosition = Vector2.zero;

        if (!isPlayer)
        {
            spawnPosition = GetRandomPositionAroundPlayer();
        }

        var entity = W.NewEntity(new Creature { IsPlayer = isPlayer });
        
        ref var position = ref entity.Ref<PositionComponent>();
        position.Position = spawnPosition;
    }

    private Vector2 GetRandomPositionAroundPlayer()
    {
        var playerPosition = Vector2.zero;

        foreach (var playerEntity in W.Query<All<PositionComponent, PlayerInputTag>>().Entities())
        {
            ref readonly var playerPos = ref playerEntity.Read<PositionComponent>();
            playerPosition = playerPos.Position;
            break;
        }

        var randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        var randomRadius = Random.Range(2f, SpawnRadius);
        
        var offset = new Vector2(
            Mathf.Cos(randomAngle) * randomRadius,
            Mathf.Sin(randomAngle) * randomRadius
        );

        return playerPosition + offset;
    }
}
}
