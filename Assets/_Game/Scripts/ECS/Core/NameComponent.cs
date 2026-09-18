using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Core
{
[Serializable]
[StaticEcsEditorName("Name")]
public struct NameComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public string Value;
}
}