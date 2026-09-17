using System;
using System.Collections.Generic;
using _Game.Scripts.ECS;
using _Game.Scripts.ECS.Core.Components;
using _Game.Scripts.ECS.Core.Components.Stats.Health;
using _Game.Scripts.ECS.Features.Endurance;
using _Game.Scripts.ECS.Features.Hunger;
using _Game.Scripts.UI.Bars;
using FFS.Libraries.StaticEcs;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private BarUI _barPrefab;
        [SerializeField] private List<BarConfig> _barConfigs = new();
        [SerializeField] private Transform _barsContainer;

        private UnitySpawner _spawner;
        private readonly List<BarUI> _activeBars = new();

        [Inject]
        private void Construct(UnitySpawner spawner)
        {
            _spawner = spawner;
            _spawner.OnPlayerSpawned += CreateBars;
        }

        private void CreateBars(EntityGID player)
        {
            foreach (var config in _barConfigs)
            {
                var bar = Instantiate(_barPrefab, _barsContainer);
                var valueReader = CreateValueReader(config.Type);
                bar.Initialize(player, config, valueReader);
                _activeBars.Add(bar);
            }
        }

        private Func<W.Entity, float> CreateValueReader(BarType type)
        {
            return type switch
            {
                BarType.Health => ReadHealthValue,
                BarType.Endurance => ReadEnduranceValue,
                BarType.Hunger => ReadHungerValue,
                _ => _ => 0f
            };
        }

        private static float ReadHealthValue(W.Entity entity)
        {
            ref readonly var current = ref entity.Read<HealthComponent>();
            ref readonly var max = ref entity.Read<MaxHealthComponent>();

            return max.Value > 0f ? current.Value / max.Value : 0f;
        }

        private static float ReadEnduranceValue(W.Entity entity)
        {
            ref readonly var current = ref entity.Read<EnduranceComponent>();
            ref readonly var max = ref entity.Read<MaxEnduranceComponent>();

            return max.Value > 0f ? current.Value / max.Value : 0f;
        }

        private static float ReadHungerValue(W.Entity entity)
        {
            ref readonly var current = ref entity.Read<HungerComponent>();
            ref readonly var max = ref entity.Read<MaxHungerComponent>();

            return max.Value > 0f ? current.Value / max.Value : 0f;
        }

        private void OnDestroy()
        {
            _spawner.OnPlayerSpawned -= CreateBars;
            foreach (var bar in _activeBars)
            {
                if (bar != null)
                    Destroy(bar.gameObject);
            }
            _activeBars.Clear();
        }
    }
}