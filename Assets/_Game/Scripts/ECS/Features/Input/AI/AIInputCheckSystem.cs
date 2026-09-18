using _Game.Scripts.ECS.Core;
using _Game.Scripts.ECS.Core.Timer;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Input.AI
{
public struct AIInputCheckSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<TimerExpiredTag, InputComponent, AIControlledTag>>().Entities())
        {
            ref var input = ref entity.Ref<InputComponent>();
            input.Current = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            
            entity.Delete<TimerExpiredTag>();
        }
    }
}
}