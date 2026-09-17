using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Input
{
[Serializable]
public struct InputComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public Vector2 Direction;
}
}