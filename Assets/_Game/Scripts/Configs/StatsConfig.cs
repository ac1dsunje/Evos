using System;
using UnityEngine;

namespace _Game.Scripts.Configs
{
[Serializable]
public class StatsConfig
{
    [Header("Attack")]
    [field: SerializeField] public float PhysicalDamage { get; private set; }
    [field: SerializeField] public float IgnoreResistance { get; private set; }
    
    [Header("Defense")]
    [field: SerializeField] public float Resistance {get; private set; }
    [field: SerializeField] public float Reflection {get; private set; }
    
    [Header("Health")]
    [field: SerializeField] public float MaxHealth { get; private set; }
    [field: SerializeField] public float ExtraLives { get; private set; }
    [field: SerializeField] public float Regeneration { get; private set; }
    
    [Header("Hunger")]
    [field: SerializeField] public float MaxHunger { get; private set; }
    
    [Header("Movement")]
    [field: SerializeField] public float MaxSpeed { get; private set; }
    [field: SerializeField] public float Acceleration { get; private set; }
    [field: SerializeField] public float Inertia { get; private set; }
    [field: SerializeField] public float DashRange { get; private set; }
    [field: SerializeField] public float SprintMultiplier {get; private set; }
}
}