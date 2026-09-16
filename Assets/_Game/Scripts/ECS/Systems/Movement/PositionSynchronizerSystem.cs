using _Game.Scripts.ECS.Components;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems.Movement
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