using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.World.Components
{
[Serializable]
public struct TransformComponent : IComponent
{
    [StaticEcsEditorTableValue] public Transform Transform;
}
}