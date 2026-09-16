using _Game.Scripts.ECS.Events;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class EntityView : MonoBehaviour
{
    public World<GameWorld>.Entity Entity;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out EntityView otherView))
        {
            W.SendEvent(new CollisionEvent
            {
                Source = Entity.GID,
                Other = otherView.Entity.GID
            });
        }
    }
}
}