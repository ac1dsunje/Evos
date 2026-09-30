using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.World.Features.InputManagement
{
[Serializable]
public struct InputComponent : IComponent
{
    [StaticEcsEditorTableValue] public Vector2 Direction;
}
}