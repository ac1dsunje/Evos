using _Game.Scripts.ECS.Core;
using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;

namespace _Game.View.Editor {
    [CustomEditor(typeof(GameWorldEventProvider)), CanEditMultipleObjects]
    public class GameWorldEventProviderEditor : StaticEcsEvenTEntityProviderEditor<GameWorld, GameWorldEventProvider> { }
}
