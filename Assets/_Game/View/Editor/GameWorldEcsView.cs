using _Game.Scripts.ECS.Core;
using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;

namespace _Game.View.Editor {
    public class GameWorldEcsView : StaticEcsView<GameWorld, GameWorldEntityProvider, GameWorldEventProvider> {
        [MenuItem("Window/GameWorld ECS")]
        public static void OpenWindow() {
            var window = GetWindow<GameWorldEcsView>();
            window.Show();
            window.Focus();
        }
    }
}
