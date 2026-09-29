using _Game.Scripts.World.Components;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World.Systems
{
public struct PositionUpdateSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<PositionComponent, RigidBodyComponent>>().Entities())
        {
            ref var position = ref entity.Ref<PositionComponent>();
            ref readonly var body = ref entity.Read<RigidBodyComponent>();
            
            position.Position = body.Body.position;
        }
    }
}
}
