using _Game.Scripts.ECS.Features.Collisions;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS
{
public class EntityView : MonoBehaviour
{
    [field: SerializeField] public Rigidbody2D Body { get; private set; }
    [field: SerializeField] public SpriteRenderer Renderer { get; private set; }
    
    public EntityGID EntityGid;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out EntityView otherView))
        {
            W.SendEvent(new CollisionEvent
            {
                Source = EntityGid,
                Other = otherView.EntityGid
            });
        }
    }
}
}