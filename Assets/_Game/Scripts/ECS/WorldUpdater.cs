using VContainer.Unity;

namespace _Game.Scripts.ECS
{
public class WorldUpdater : ITickable, IFixedTickable
{
    public void Tick()
    {
        GameSys.Update();
        W.Tick();
    }

    public void FixedTick()
    {
        FixedSys.Update();
    }
}
}