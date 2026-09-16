using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Components
{
public struct PhysicsMaterialComponent : IComponent, INonSerializable
{
    public PhysicsMaterial2D Material;

    public void OnDelete(World<GameWorld>.Entity entity, HookReason reason)
    {
        if (Material != null)
        {
            Object.Destroy(Material);
        }
    }
}
}