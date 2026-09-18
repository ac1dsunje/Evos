using _Game.Scripts.ECS.Core.EntityTypes;
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
            if (level.Value == 0) continue;

            if (entity.Is<Creature>())
            {
                for (var i = 0; i < 3; i++)
                {
                    W.NewEntity<Evolution>().Set(
                        new ExperienceComponent { Set = 5 }
                    );
                }
            }
            else if (entity.Is<Evolution>())
            {
                Debug.Log($"evolution level up!");
            }
        }
    }
}
}