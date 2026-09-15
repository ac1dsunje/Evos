using _Game.Scripts.ECS;
using _Game.Scripts.ECS.Components;
using _Game.Scripts.ECS.Components.Events;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts
{
public class EntityView : MonoBehaviour
{
    public World<GameWorld>.Entity Entity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EntityView otherView))
        {
            W.NewEntity<Default>().Set(new CollisionEvent
            {
                Attacker = Entity,
                Target = otherView.Entity
            });
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
}