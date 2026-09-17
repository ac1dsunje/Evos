using System;
using UnityEngine;

namespace _Game.Scripts.Configs
{
[Serializable]
public class StatsConfig
{
    [Header("Attack")]
    [field: SerializeField] public float PhysicalDamage { get; private set; }
    
    [Header("Breathing")]
    [field: SerializeField] public float OxygenRequirement { get; private set; }
    [field: SerializeField] public float HydrogenRequirement { get; private set; }
    
    [Header("Defense")]
    [field: SerializeField] public float DamageResistance {get; private set; }
    [field: SerializeField] public float DamageReflection {get; private set; }
    
    [Header("Endurance")]
    [field: SerializeField] public float MaxEndurance { get; private set; }
    [field: SerializeField] public float EnduranceRecovery { get; private set; }
    
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
    [field: SerializeField] public float PassAbility { get; private set; }
    [field: SerializeField] public float SprintMultiplier {get; private set; }
    
    [Header("Temperature")]
    [field: SerializeField] public float ColdResistance { get; private set; }
    [field: SerializeField] public float HotResistance { get; private set; }
    
    [Header("Social")]
    [field: SerializeField] public float Influence { get; private set; }
    
    [Header("Other")]
    [field: SerializeField] public float PickingRange { get; private set; }
}
}