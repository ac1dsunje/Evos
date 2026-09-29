using UnityEngine;

namespace _Game.Scripts.World.Configuration
{
[CreateAssetMenu(fileName = "CreatureConfig", menuName = "World/Creature")]
public class CreatureConfig : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    
    [field: SerializeField] public float MaxHealth { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
}
}