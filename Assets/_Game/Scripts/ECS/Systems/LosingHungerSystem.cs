using System;
using _Game.Scripts.ECS.Components;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
public struct LosingHungerSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<HungerComponent>>().Entities())
        {
            ref var current = ref entity.Ref<HungerComponent>();

            current.Value = MathF.Max(current.Value - Time.deltaTime * 1/5f, 0);
        }
    }
}
}