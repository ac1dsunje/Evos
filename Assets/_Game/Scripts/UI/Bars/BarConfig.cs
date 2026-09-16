using UnityEngine;

namespace _Game.Scripts.UI.Bars
{

[CreateAssetMenu(fileName = "NewBarConfig", menuName = "Configs/Bar")]
public class BarConfig : ScriptableObject
{
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}
}