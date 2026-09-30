using _Game.Scripts.World.Entities;
using _Game.Scripts.World.Features.InputManagement;
using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World.Features.Spawn
{
public struct PlayerSpawnSystem : ISystem
{
    public void Init()
    {
        var entity = W.NewEntity(new Creature
        {
            Config = W.GetResource<CreatureConfigsResource>().PlayerConfig
        });
        
        entity.Set<IsPlayerTag>();
    }
}
}
