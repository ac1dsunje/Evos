using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Breathing
{
public struct BreathingCheckSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<AllChanged<OxygenRequirementComponent>>().Entities())
        {
            ref readonly var oxygen = ref entity.Read<OxygenRequirementComponent>();
            if (oxygen.Value > 0 && !entity.HasEnabled<OxygenRequirementComponent>())
                entity.Enable<OxygenRequirementComponent>();
            else if (oxygen.Value <= 0 && entity.HasEnabled<OxygenRequirementComponent>())
                entity.Disable<OxygenRequirementComponent>();
        }

        foreach (var entity in W.Query<AllChanged<HydrogenRequirementComponent>>().Entities())
        {
            ref readonly var hydrogen = ref entity.Read<HydrogenRequirementComponent>();
            if (hydrogen.Value > 0 && !entity.HasEnabled<HydrogenRequirementComponent>())
                entity.Enable<HydrogenRequirementComponent>();
            else if (hydrogen.Value <= 0 && entity.HasEnabled<HydrogenRequirementComponent>())
                entity.Disable<HydrogenRequirementComponent>();
        }
    }
}
}