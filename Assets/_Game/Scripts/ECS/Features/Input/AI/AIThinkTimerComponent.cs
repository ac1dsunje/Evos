using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Features.Input.AI
{
[StaticEcsEditorName("AIThinkTimer")]
public struct AIThinkTimerComponent : IComponent
{
    public float Current;
    public float Interval;
}
}