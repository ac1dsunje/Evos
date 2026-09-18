using _Game.Scripts.ECS.Core;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Experience
{
public struct ExperienceUpdateSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<AllChanged<ExperienceComponent>>().Entities())
        {
            ref var experience = ref entity.Mut<ExperienceComponent>();

            while (experience.Value >= experience.Set)
            {
                experience.Value -= experience.Set;
                experience.Set++;
            
                ref var level = ref entity.Mut<LevelComponent>();
                level.Value++;
            }
        }
    }
}
}