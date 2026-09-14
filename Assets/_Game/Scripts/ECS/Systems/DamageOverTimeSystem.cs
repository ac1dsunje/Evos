using _Game.Scripts.ECS.Components;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
public struct DamageOverTimeSystem : ISystem
{
    private float _timer;
    private const float DamageInterval = 1.0f;

    public void Update()
    {
        _timer += Time.deltaTime;

        if (_timer < DamageInterval) return;
        
        _timer = 0f;

        foreach (var entity in W.Query<All<HealthComponent>>().Entities())
        {
            ref var health = ref entity.Ref<HealthComponent>();

            health.Current -= 1f;
            
            if (!(health.Current <= 0f)) continue;
            
            entity.Destroy();
        }
    }
}
}