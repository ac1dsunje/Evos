using _Game.Scripts.ECS.Features.Experience;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Core.EntityTypes
{
public struct Evolution : IEntityType
{
    public byte Id() => 2;
    
    public void OnCreate<TWorld>(World<TWorld>.Entity entity) where TWorld : struct, IWorldType {
        entity.Set(
            new LevelComponent()
        );
    }
}
}