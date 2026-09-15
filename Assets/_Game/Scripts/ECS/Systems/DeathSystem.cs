using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Tags;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems
{
public struct DeathSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<
                     DeadTag,
                     ViewComponent
                 >>().Entities())
        {
            ref var view = ref entity.Ref<ViewComponent>();
            
            view.View.DestroySelf();
            
            entity.Destroy();
        }
    }
}
}