using _Game.Scripts.World.Configuration;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World.WorldResources
{
public struct CreatureConfigsResource : IResource
{
    public CreatureConfig PlayerConfig;
    public CreatureConfig SlimeConfig;
}
}