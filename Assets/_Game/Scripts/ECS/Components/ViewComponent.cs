using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Components
{
public struct ViewComponent : IComponent
{
    public EntityView View;
    
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