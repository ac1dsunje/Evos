using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.Configs
{
[CreateAssetMenu(fileName = "CreatureSpawnerConfig", menuName = "Configs/Creatures/Spawner")]
public class CreaturesSpawnerConfig : ScriptableObject, IResource
{
    [field: SerializeField] public int MaxCreatures { get; private set; }= 500;
    [field: SerializeField] public float Interval { get; private set; } = 1f;
}
}