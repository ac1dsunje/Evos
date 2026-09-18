using _Game.Scripts.ECS.Core;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Regeneration
{
public struct RegenerationCheckSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<AllChanged<RegenerationComponent>>().Entities())
        {
            ref readonly var regen = ref entity.Read<RegenerationComponent>();
            
            if (regen.Value > 0 && !entity.HasEnabled<RegenerationComponent>())
            {
                entity.Enable<RegenerationComponent>();
            }
            else if (regen.Value <= 0 && entity.HasEnabled<RegenerationComponent>())
            {
                entity.Disable<RegenerationComponent>();
            }
        }
    }
}
}