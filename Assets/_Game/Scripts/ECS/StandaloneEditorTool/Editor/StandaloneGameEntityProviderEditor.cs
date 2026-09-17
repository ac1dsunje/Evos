using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;

namespace _Game.Scripts.ECS.StandaloneEditorTool.Editor
{
    [CustomEditor(typeof(StandaloneGameEntityProvider)), CanEditMultipleObjects]
    public class StandaloneGameEntityProviderEditor : StaticEcsEntityProviderEditor<GameWorld, StandaloneGameEntityProvider>
    {
    }
}
