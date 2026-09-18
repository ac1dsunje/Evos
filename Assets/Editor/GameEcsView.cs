using _Game.Scripts.ECS.Core;
using _Game.Scripts.ECS.Providers;
using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;

namespace Editor
{
public class GameEcsView : StaticEcsView<GameWorld, EntityProvider, EventProvider>
{
    [MenuItem("Window/StaticECS/OpenView")]
    public static void OpenWindow()
    {
        var window = GetWindow<GameEcsView>();
        window.Show();
        window.Focus();
    }
}
}
