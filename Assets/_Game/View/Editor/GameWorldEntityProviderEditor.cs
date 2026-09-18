using _Game.Scripts.ECS.Core;
using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;

namespace _Game.View.Editor {
    [CustomEditor(typeof(GameWorldEntityProvider)), CanEditMultipleObjects]
    public class GameWorldEntityProviderEditor : StaticEcsEntityProviderEditor<GameWorld, GameWorldEntityProvider> { }
}
