using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Stats;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Systems
{
    public struct PhysicsMaterialSystem : ISystem
    {
        public void Update()
        {
            foreach (var entity in W.Query<
                And<
                    AllAdded<FrictionComponent, BouncinessComponent>,
                    All<RigidBodyComponent>,
                    None<PhysicsMaterialComponent>
                >>().Entities())
            {
                ref readonly var rb = ref entity.Read<RigidBodyComponent>();

                var friction = entity.Has<FrictionComponent>()
                    ? entity.Read<FrictionComponent>().Value
                    : 0f;

                var bounciness = entity.Has<BouncinessComponent>()
                    ? entity.Read<BouncinessComponent>().Value
                    : 0f;

                var material = new PhysicsMaterial2D
                {
                    friction = friction,
                    bounciness = bounciness
                };

                rb.Body.sharedMaterial = material;
                entity.Set(new PhysicsMaterialComponent { Material = material });
            }

            foreach (var entity in W.Query<
                And<
                    AnyChanged<FrictionComponent, BouncinessComponent>,
                    All<PhysicsMaterialComponent>
                >>().Entities())
            {
                ref readonly var mat = ref entity.Read<PhysicsMaterialComponent>();

                if (entity.Has<FrictionComponent>())
                    mat.Material.friction = entity.Read<FrictionComponent>().Value;

                if (entity.Has<BouncinessComponent>())
                    mat.Material.bounciness = entity.Read<BouncinessComponent>().Value;
            }
        }
    }
}