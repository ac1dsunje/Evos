using VContainer.Unity;

namespace _Game.Scripts.ECS
{
public class WorldUpdater : ITickable
{
    public void Tick()
    {
        GameSys.Update();
        W.Tick();
    }
}
}