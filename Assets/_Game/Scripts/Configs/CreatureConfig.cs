using UnityEngine;

namespace _Game.Scripts.Configs
{
[CreateAssetMenu(fileName = "CreatureConfig", menuName = "Configs/Creature")]
public class CreatureConfig : ScriptableObject
{
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public ExperienceConfig Experience { get; private set; }
    [field: SerializeField] public StatsConfig Stats { get; private set; }
}
}