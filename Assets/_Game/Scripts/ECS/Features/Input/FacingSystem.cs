using _Game.Scripts.ECS.Features.Body;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Input
{
public struct FacingSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<TransformComponent, InputComponent>>().Entities())
        {
            ref readonly var input = ref entity.Read<InputComponent>();
            
            var hasMovement = input.Direction.sqrMagnitude > 0.001f;
            if (!hasMovement) continue;
            
            ref var view = ref entity.Ref<TransformComponent>();
            
            var currentScale = view.Transform.transform.localScale;
            currentScale.x = input.Direction.x < 0f ? -1f : 1f;
            view.Transform.transform.localScale = currentScale;
        }
    }
}
}