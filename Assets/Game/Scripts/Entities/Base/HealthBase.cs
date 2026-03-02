using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    public class HealthBase : MonoBehaviour, IDamageable
    {
        [SerializeField] protected float _health;
        
        public void TakeDamage(float damage)
        {
            _health -= damage;
        }
    }
}