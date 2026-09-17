using _Game.Scripts.ECS.Core.Components;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Core.Systems.Movement
{
public struct PositionSynchronizerSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<PositionComponent, RigidBodyComponent>>().Entities())
        {
            ref var position = ref entity.Ref<PositionComponent>();
            ref readonly var rigidBody = ref entity.Read<RigidBodyComponent>();
            
            position.Position = rigidBody.Body.transform.position;
        }
    }
}
}