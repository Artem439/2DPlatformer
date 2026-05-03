using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] private HealthBase _health;
        
        public HealthBase Health => _health;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ICollectable collectable))
            {
                collectable.Collect(this);
            }
        }
    }
}