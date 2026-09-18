using _Game.Scripts.ECS.Features.Body;
using _Game.Scripts.ECS.Features.Experience;
using _Game.Scripts.ECS.Features.Input;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Core.EntityTypes
{
public struct Creature : IEntityType
{
    public byte Id() => 1;
    
    public void OnCreate<TWorld>(World<TWorld>.Entity entity) where TWorld : struct, IWorldType {
        entity.Set(
            new PositionComponent(),
            new InputComponent(),
            new LevelComponent()
            );
    }
}
}