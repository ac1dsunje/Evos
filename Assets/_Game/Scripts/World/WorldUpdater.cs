using _Game.Scripts.World.WorldResources;
using UnityEngine;
using VContainer.Unity;

namespace _Game.Scripts.World
{
public class WorldUpdater : ITickable, IFixedTickable
{
    public void Tick()
    {
        W.SetResource(new DeltaTimeResource { Value = Time.deltaTime });
        
        GameSys.Update();
        InputSys.Update();
        
        W.Tick();
    }

    public void FixedTick()
    {
        W.SetResource(new FixedDeltaTimeResource { Value = Time.fixedDeltaTime });
        
        FixedSys.Update();
    }
}
}