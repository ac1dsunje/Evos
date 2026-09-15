using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
public class PlayerInputCheckSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<
                     InputComponent, 
                     PlayerControlledTag
                 >>().Entities())
        {
            ref var input = ref entity.Ref<InputComponent>();
            
            input.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}
}