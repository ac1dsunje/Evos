using UnityEngine;

namespace _Game.Scripts.UI.Bars
{
public enum BarType
{
    Health = 0,
    Endurance = 1,
    Hunger = 2
}
[CreateAssetMenu(fileName = "NewBarConfig", menuName = "Configs/Bar")]
public class BarConfig : ScriptableObject
{
    [field: SerializeField] public BarType Type { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}
}