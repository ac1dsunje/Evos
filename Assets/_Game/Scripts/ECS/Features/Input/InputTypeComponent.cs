using System;
using _Game.Scripts.Configs;
using _Game.Scripts.ECS.Core.Timer;
using _Game.Scripts.ECS.Features.Input.AI;
using _Game.Scripts.ECS.Features.Input.Player;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Config
{
public struct InputTypeComponent : IComponent
{
    public CreatureInput Config;

    public void OnAdd<TWorld>(World<TWorld>.Entity self) where TWorld : struct, IWorldType
    {
        switch (Config)
        {
            case CreatureInput.AI:
                self.Set<AIControlledTag>();
                self.Set(new TimerComponent { Interval = 1f });
                break;
            case CreatureInput.Player:
                self.Set<PlayerControlledTag>();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
}