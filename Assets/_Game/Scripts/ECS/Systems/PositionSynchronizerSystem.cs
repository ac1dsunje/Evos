using _Game.Scripts.ECS.Components;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems
{
public struct PositionSynchronizerSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<
                     All<PositionComponent, RigidBodyComponent>
                 >().Entities())
        {
            ref var position = ref entity.Ref<PositionComponent>();
            ref var rigidBody = ref entity.Ref<RigidBodyComponent>();
            if (rigidBody.Body == null) return;
            position.Position = rigidBody.Body.transform.position;
        }
    }
}
}