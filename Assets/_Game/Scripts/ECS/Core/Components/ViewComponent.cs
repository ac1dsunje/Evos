using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;

namespace _Game.Scripts.ECS.Core.Components
{
public struct ViewComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public EntityView View;
    
    public void OnDelete<TW>(World<TW>.Entity entity, HookReason reason) where TW : struct, IWorldType
    {
        if (reason == HookReason.WorldDestroy) return;
        if (View != null)
        {
            Object.Destroy(View.gameObject);
        }
    }
}
}