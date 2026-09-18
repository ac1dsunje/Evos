using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Biomes.Breathing
{
public struct BreathingCheckSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<AllChanged<OxygenComponent>>().Entities())
        {
            ref readonly var oxygen = ref entity.Read<OxygenComponent>();
            if (oxygen.Value > 0 && !entity.HasEnabled<OxygenComponent>())
                entity.Enable<OxygenComponent>();
            else if (oxygen.Value <= 0 && entity.HasEnabled<OxygenComponent>())
                entity.Disable<OxygenComponent>();
        }

        foreach (var entity in W.Query<AllChanged<HydrogenComponent>>().Entities())
        {
            ref readonly var hydrogen = ref entity.Read<HydrogenComponent>();
            if (hydrogen.Value > 0 && !entity.HasEnabled<HydrogenComponent>())
                entity.Enable<HydrogenComponent>();
            else if (hydrogen.Value <= 0 && entity.HasEnabled<HydrogenComponent>())
                entity.Disable<HydrogenComponent>();
        }
    }
}
}