using _Game.Scripts.ECS.Components;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
public class MoveOverTimeSystem: ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<PositionComponent, SpeedComponent>>().Entities())
        {
            ref var position = ref entity.Ref<PositionComponent>();
            ref var speed  = ref entity.Ref<SpeedComponent>();

            position.Position.x+= speed.Speed * Time.deltaTime;
            Debug.Log($"entity {entity.ID}: Position: {position.Position} | Speed: {speed.Speed}");
        }
    }
}
}