using Game.Scripts.Entities.Base;
using UnityEngine;

namespace UI
{
    public class HealthBarChanger : BaseBarChanger
    {
        [SerializeField] private HealthBase _playerHealth;

        private void OnEnable()
        {
            _playerHealth.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _playerHealth.HealthChanged -= OnHealthChanged;
        }
        
        private void OnHealthChanged(float currentHealth, float maxHealth)
        {
            UpdateBar(currentHealth, maxHealth);
        }
    }
}