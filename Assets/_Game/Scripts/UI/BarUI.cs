using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
public class BarUI : MonoBehaviour
{
    [SerializeField] private Color _fillColor = Color.white;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Image _fill;
    [SerializeField] private Image _background;

    private void Start()
    {
        _fill.color = _fillColor;
    }
}
}