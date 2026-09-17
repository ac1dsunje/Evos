using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Experience
{
public struct LevelUpdateSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<AllChanged<LevelComponent>>().Entities())
        {
            ref readonly var level = ref entity.Read<LevelComponent>();
            Debug.Log($"new level {level.Value}");
        }
    }
}
}