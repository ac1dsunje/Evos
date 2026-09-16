using _Game.Scripts.ECS;
using _Game.Scripts.ECS.Components.Requests;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts
{
public class EntityView : MonoBehaviour
{
    public World<GameWorld>.Entity Entity;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out EntityView otherView))
        {
            W.NewEntity<Default>().Set(new CollisionRequest
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