using _Game.Scripts.ECS.Core.WorldResources;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Core.Timer
{
public struct TimerSystem : ISystem
{
    public void Update()
    {
        var dt = W.GetResource<DeltaTimeResource>().Value;
        
        foreach (var entity in W.Query<All<TimerComponent>>().Entities())
        {
            ref var timer = ref entity.Ref<TimerComponent>();
            timer.Current += dt;

            if (timer.Current < timer.Interval) continue;
            
            timer.Current -= timer.Interval;
            entity.Set<TimerExpiredTag>();
        }
    }
}
}