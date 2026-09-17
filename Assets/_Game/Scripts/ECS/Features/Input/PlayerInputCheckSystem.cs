using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Input
{
public struct PlayerInputCheckSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<InputComponent, PlayerControlledTag>>().Entities())
        {
            ref var input = ref entity.Ref<InputComponent>();
            input.Direction = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
        }
    }
}
}