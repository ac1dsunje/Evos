using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Scripts.ECS.Features.Body
{
[Serializable]
[StaticEcsEditorName("CreatureView")]
public struct CreatureViewComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public EntityView View;

    public void OnAdd<TWorld>(World<TWorld>.Entity self) where TWorld : struct, IWorldType
    {
        Debug.Log($"add creature view component");
    }

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