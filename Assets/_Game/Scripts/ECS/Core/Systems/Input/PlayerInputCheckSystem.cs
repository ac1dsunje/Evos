using _Game.Scripts.ECS.Core.Components;
using _Game.Scripts.ECS.Core.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Core.Systems.Input
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