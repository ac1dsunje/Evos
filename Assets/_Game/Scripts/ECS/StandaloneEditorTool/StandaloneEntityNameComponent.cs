using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.ECS.StandaloneEditorTool
{
    [StaticEcsEditorName("EntityName", "EntityName")]
    [StaticEcsEditorGroup("Debug", "A0AEA1")]
    public struct StandaloneEntityNameComponent : IComponent
    {
        public const string EditorFullName = "EntityName";

        [StaticEcsEditorTableValue(180f)] public string _value;
    }
}
