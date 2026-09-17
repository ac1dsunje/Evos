using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.Components
{
[StaticEcsEditorGroup("Debug", "A0AEA1")]
public struct NameComponent : IComponent
{
    public const string EditorFullName = "EntityName";

    [StaticEcsEditorTableValue(180f)] public string Value;
}
}
