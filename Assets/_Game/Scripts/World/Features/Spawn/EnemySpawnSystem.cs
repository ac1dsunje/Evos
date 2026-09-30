using _Game.Scripts.World.Entities;
using _Game.Scripts.World.Features.InputManagement;
using _Game.Scripts.World.Features.Movement;
using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Features.Spawn
{
public struct EnemySpawnSystem : ISystem
{
    private const int MaxEnemies = 50;
    private const float SpawnRadius = 10f;
    private const float SpawnInterval = 0.5f;

    private float _spawnTimer;

    public void Update()
    {
        _spawnTimer += W.GetResource<DeltaTimeResource>().Value;
        if (_spawnTimer < SpawnInterval) return;
        _spawnTimer = 0f;

        var enemyCount = 0;
        foreach (var _ in W.Query<All<RandomInputTag>>().Entities())
        {
            enemyCount++;
        }

        if (enemyCount >= MaxEnemies) return;

        var spawnPosition = GetRandomPositionAroundPlayer();

        var entity = W.NewEntity(new Creature
        {
            Config = W.GetResource<CreatureConfigsResource>().SlimeConfig
        });
        
        entity.Set<RandomInputTag>();

        ref var position = ref entity.Ref<PositionComponent>();
        position.Position = spawnPosition;
    }

    private Vector2 GetRandomPositionAroundPlayer()
    {
        var playerPosition = Vector2.zero;

        foreach (var playerEntity in W.Query<All<IsPlayerTag>>().Entities())
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
