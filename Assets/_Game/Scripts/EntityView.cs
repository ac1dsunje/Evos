using _Game.Scripts.ECS;
using _Game.Scripts.ECS.Tags;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts
{
public class EntityView : MonoBehaviour
{
    private World<GameWorld>.Entity _entity;

    public void SetEntity(World<GameWorld>.Entity entity) => _entity = entity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EntityView view))
        {
            _entity.Set<DeadTag>();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
}