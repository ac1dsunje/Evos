using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;

namespace _Game.Scripts.ECS.StandaloneEditorTool.Editor
{
    [CustomEditor(typeof(StandaloneGameEventProvider)), CanEditMultipleObjects]
    public class StandaloneGameEventProviderEditor : StaticEcsEvenTEntityProviderEditor<GameWorld, StandaloneGameEventProvider>
    {
    }
}
