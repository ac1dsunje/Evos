using System;
using _Game.Scripts.ECS;
using FFS.Libraries.StaticEcs;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI.Bars
{
public class BarUI : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private Image _fill;
    [SerializeField] private Image _background;
    
    private EntityGID _targetGid;
    private Func<World<GameWorld>.Entity, float> _valueReader;

    public void Initialize(EntityGID targetGid, BarConfig config, Func<World<GameWorld>.Entity, float> valueReader)
    {
        _targetGid = targetGid;
        _valueReader = valueReader;

        _fill.color = config.Color;
        _iconImage.sprite = config.Sprite;
    }

    private void Update()
    {
        if (_targetGid == default || _valueReader == null)
            return;

        if (!_targetGid.TryUnpack<GameWorld>(out var entity))
        {
            _fill.fillAmount = 0f;
            return;
        }

        _fill.fillAmount = _valueReader(entity);
    }
}
}