using _Game.Scripts.ECS.Core.Components;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Core.Systems
{
public struct FacingSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<ViewComponent, InputComponent>>().Entities())
        {
            ref var view = ref entity.Ref<ViewComponent>();
            ref readonly var input = ref entity.Read<InputComponent>();
            
            var hasMovement = input.Direction.sqrMagnitude > 0.001f;
            if (!hasMovement) continue;
            
            var currentScale = view.View.transform.localScale;
            currentScale.x = input.Direction.x < 0f ? -1f : 1f;
            view.View.transform.localScale = currentScale;
        }
    }
}
}