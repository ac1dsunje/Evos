using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.Features.Input.AI
{
public struct AIThinkTimer : IComponent
{
    public float Current;
    public float Interval;
}
}