using System;
using _Game.Scripts.ECS.Core.WorldResources;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Hunger
{
public struct LosingHungerSystem : ISystem
{
    public void Update()
    {
        var deltaTime = W.GetResource<DeltaTimeResource>().Value;
        var hungerDecayRate = W.GetResource<HungerDecayRate>().Value;
        
        foreach (var entity in W.Query<All<HungerComponent>>().Entities())
        {
            ref var current = ref entity.Mut<HungerComponent>();

            current.Value = MathF.Max(current.Value - deltaTime * hungerDecayRate, 0);
        }
    }
}
}