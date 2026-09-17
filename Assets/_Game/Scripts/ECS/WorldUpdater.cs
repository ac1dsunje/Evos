using _Game.Scripts.ECS.Core.WorldResources;
using UnityEngine;
using VContainer.Unity;

namespace _Game.Scripts.ECS
{
public class WorldUpdater : ITickable, IFixedTickable
{
    public void Tick()
    {
        W.SetResource(new DeltaTimeResource { Value = Time.deltaTime });
        
        GameSys.Update();
        
        W.Tick();
    }

    public void FixedTick()
    {
        W.SetResource(new FixedDeltaTimeResource { Value = Time.fixedDeltaTime });
        
        FixedSys.Update();
    }
}
}