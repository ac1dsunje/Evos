using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Core.Timer
{
[StaticEcsEditorName("Timer")]
public struct TimerComponent : IComponent
{
    public float Current;
    public float Interval;
}
}