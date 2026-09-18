using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using Vector2 = UnityEngine.Vector2;

namespace _Game.Scripts.ECS.Features.Input
{
[Serializable]
[StaticEcsEditorName("Input")]
public struct InputComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public Vector2 Current;
}
}