using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.Configs
{
public enum CreatureInput
{
    AI = 0,
    Player = 1,
}

[CreateAssetMenu(fileName = "CreatureConfig", menuName = "Configs/Creatures/Creature")]
public class CreatureConfig : ScriptableObject, IResource
{
    [field: SerializeField] public CreatureInput Input { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public ExperienceConfig Experience { get; private set; }
    [field: SerializeField] public StatsConfig Stats { get; private set; }
}
}