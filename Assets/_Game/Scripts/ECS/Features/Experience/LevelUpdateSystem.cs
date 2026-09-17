using _Game.Scripts.ECS.Core.EntityTypes;
using FFS.Libraries.StaticEcs;

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

            for (var i = 0; i < 3; i++)
            {
                W.NewEntity<Evolution>().Set(
                    new ExperienceComponent { Value = 0, Set = 5 },
                    new LevelComponent { Value = 0 }
                );
            }
        }
    }
}
}