using _Game.Scripts.ECS.Events;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Systems
{
public struct DeathSystem : ISystem
{
    private EventReceiver<GameWorld, DeathEvent> _receiver;

    public void Init()
    {
        _receiver = W.RegisterEventReceiver<DeathEvent>();
    }

    public void Update()
    {
        foreach (var e in _receiver)
        {
            if (!e.Value.Entity.TryUnpack<GameWorld>(out var entity)) continue;
            
            entity.Destroy();
        }
    }
}
}