using _Game.Scripts.World.Components;
using _Game.Scripts.World.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Systems
{
public struct PlayerInputSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<InputComponent, PlayerInputTag>>().Entities())
        {
            ref var input = ref entity.Ref<InputComponent>();
            input.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}
}