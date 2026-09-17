using System;
using UnityEngine;

namespace _Game.Scripts.Configs
{
[Serializable]
public class ExperienceConfig
{
    [field: SerializeField] public int Set { get; private set; } = 5;
}
}