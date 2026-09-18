using System;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Scripts.ECS.Features.Body
{
[Serializable]
[StaticEcsEditorName("Transform")]
public struct TransformComponent : IComponent
{
    [StaticEcsEditorTableValue(180f)] public Transform Transform;

    public void OnDelete<TW>(World<TW>.Entity entity, HookReason reason) where TW : struct, IWorldType
    {
        if (reason == HookReason.WorldDestroy) return;
        if (Transform != null)
        {
            Object.Destroy(Transform.gameObject);
        }
    }
}
}