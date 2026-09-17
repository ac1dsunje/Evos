using _Game.Scripts.ECS;
using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(EntityProvider)), CanEditMultipleObjects]
    public class EntityProviderEditor : StaticEcsEntityProviderEditor<GameWorld, EntityProvider>
    {
    }
}
