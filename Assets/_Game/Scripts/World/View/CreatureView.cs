using UnityEngine;

namespace _Game.Scripts.World.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CreatureView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        private void OnEnable()
        {
            if (_rigidbody2D != null)
            {
                _rigidbody2D.linearVelocity = Vector2.zero;
                _rigidbody2D.angularVelocity = 0f;
            }
        }

        private void OnDisable()
        {
            if (_rigidbody2D != null)
            {
                _rigidbody2D.linearVelocity = Vector2.zero;
                _rigidbody2D.angularVelocity = 0f;
            }
        }
    }
}
