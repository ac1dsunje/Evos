using _Game.Scripts.ECS.Core;
using _Game.Scripts.ECS.Features.Dashing;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Input.Player
{
public struct PlayerInputCheckSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<InputComponent, PlayerControlledTag>>().Entities())
        {
            ref var input = ref entity.Ref<InputComponent>();
            input.Current = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));

            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                entity.Set<DashTag>();
            }
        }
    }
}
}