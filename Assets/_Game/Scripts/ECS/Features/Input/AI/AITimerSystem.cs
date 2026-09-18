using _Game.Scripts.ECS.Core.WorldResources;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Input.AI
{
public struct AITimerSystem : ISystem
{
    public void Update()
    {
        var dt = W.GetResource<DeltaTimeResource>().Value;
        
        foreach (var entity in W.Query<All<AIThinkTimerComponent>>().Entities())
        {
            ref var timer = ref entity.Ref<AIThinkTimerComponent>();
            timer.Current += dt;
        }
    }
}
}