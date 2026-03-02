using System;
using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    public class HealthBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _health;
        
        public event Action CharacterDeath;

        private void OnValidate()
        {
            if (_health <= 0)
                _health = 1;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            
            if (_health <= 0)
                CharacterDeath?.Invoke();
        }
    }
}