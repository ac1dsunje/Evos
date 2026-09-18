using _Game.Scripts.ECS.Core.Timer;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Input.AI
{
public struct AIInputCheckSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<InputComponent, AIControlledTag, TimerComponent>>().Entities())
        {
            ref var timer = ref entity.Ref<TimerComponent>();
            
            if (timer.Current >= timer.Interval)
            {
                timer.Current -= timer.Interval;
                ref var input = ref entity.Ref<InputComponent>();
                
                input.Direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            }
        }
    }
}
}