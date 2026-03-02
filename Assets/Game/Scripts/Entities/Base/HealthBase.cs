using System;
using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    public class HealthBase : MonoBehaviour, IDamageable
    {
        [Min(1)] private float _maxHealth;
        
        private float _currentHealth;
        
        public event Action Death;

        private void OnValidate()
        {
            if (_maxHealth <= 0)
                _maxHealth = 1;
        }

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (damage > _currentHealth)
                _currentHealth = 0;
            else
                _currentHealth -= damage;
            
            if (_maxHealth <= 0)
                Death?.Invoke();
        }
    }
}