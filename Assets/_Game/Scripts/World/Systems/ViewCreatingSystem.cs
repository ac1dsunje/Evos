using _Game.Scripts.World.Components;
using _Game.Scripts.World.Tags;
using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Systems
{
public struct ViewCreatingSystem : ISystem
{
    public void Update()
    {
        foreach (var entity in W.Query<All<AddViewTag>>().Entities())
        {
            if (entity.Has<RigidBodyComponent>())
            {
                entity.Delete<AddViewTag>();
                continue;
            }
            
            var view = Object.Instantiate(W.GetResource<CreatureViewPrefabResource>().Prefab);

            entity.Set(
                new RigidBodyComponent { Body = view.Rigidbody2D },
                new TransformComponent { Transform = view.transform }
                );
            entity.Delete<AddViewTag>();
        }
    }
}
}