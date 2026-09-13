using _Game.Scripts.Components;
using FFS.Libraries.StaticEcs;
using UnityEngine;
using VContainer.Unity;

namespace _Game.Scripts.Systems
{
// Реализуем ITickable, чтобы VContainer вызывал Tick() каждый кадр
public class DamageOverTimeSystem : ITickable
{
    private float _timer;
    private const float DamageInterval = 1.0f;

    public void Tick()
    {
        _timer += Time.deltaTime;

        if (_timer >= DamageInterval)
        {
            _timer = 0f;

            // 1. Создаем фильтр: "Дай мне все сущности, у которых есть HealthComponent"
            // All<T> означает, что у сущности должен быть этот компонент
            foreach (var entity in W.Query<All<HealthComponent>>().Entities())
            {
                // 2. Получаем компонент ПО ССЫЛКЕ (ref). 
                // Это критически важно для производительности ECS!
                ref var health = ref entity.Ref<HealthComponent>();

                // Наносим урон
                health.Current -= 1f;
                Debug.Log($"Сущность {entity.ID} получила урон. Текущее HP: {health.Current}");

                // Проверка на смерть
                if (health.Current <= 0f)
                {
                    Debug.Log($"Сущность {entity.ID} уничтожена!");
                    entity.Destroy(); // Уничтожаем сущность через API StaticECS
                }
            }
        }
    }
}
}