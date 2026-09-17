using _Game.Scripts.ECS;
using _Game.Scripts.ECS.StandaloneEditorTool;
using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(StandaloneGameEntityProvider)), CanEditMultipleObjects]
    public class StandaloneGameEntityProviderEditor : StaticEcsEntityProviderEditor<GameWorld, StandaloneGameEntityProvider>
    {
    }
}
