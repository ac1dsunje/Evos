using _Game.Scripts.ECS;
using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats.Health;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Game.Scripts.UI.Bars
{
public class BarUI : MonoBehaviour
{
    [SerializeField] private BarConfig _config;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Image _fill;
    [SerializeField] private Image _background;
        
    private UnitySpawner _spawner;

    [Inject]
    private void Construct(UnitySpawner spawner)
    {
        _spawner = spawner;
    }

    private void Start()
    {
        _fill.color = _config.Color;
        _iconImage.sprite = _config.Sprite;
    }

    private void Update()
    {
        if (_spawner.PlayerGid == default)
            return;

        if (!_spawner.PlayerGid.TryUnpack<GameWorld>(out var entity))
        {
            _fill.fillAmount = 0f;
            return;
        }

        if (!entity.Has<HealthComponent>() || !entity.Has<MaxHealthComponent>())
        {
            _fill.fillAmount = 0f;
            return;
        }

        ref readonly var health = ref entity.Read<HealthComponent>();
        ref readonly var maxHealth = ref entity.Read<MaxHealthComponent>();

        _fill.fillAmount = health.Value / maxHealth.Value;
    }
}
}