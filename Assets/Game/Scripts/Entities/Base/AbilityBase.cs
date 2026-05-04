using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    public abstract class AbilityBase : MonoBehaviour
    {
        [SerializeField] protected float _activeDelay;
        [SerializeField] protected float _cooldownDelay;
        [SerializeField] protected float _abilityDamage;
        
        private bool _isReady = true;
        
        public event Action<float, float> ProgressChanged;
        public event Action<bool> AbilityActivated;
        
        protected abstract void Execute();

        public void Activate()
        {
            if (_isReady)
            {
                StartCoroutine(AbilityCoroutine());
            }
        }
        
        private IEnumerator AbilityCoroutine()
        {
            float elapsed = 0f;
            float cooldown = 0f;
            
            _isReady = false;

            AbilityActivated?.Invoke(true);
            
            while (elapsed <= _activeDelay)
            {
                Execute();
                
                elapsed += Time.deltaTime;
                
                ProgressChanged?.Invoke(1 - (elapsed / _activeDelay), 1f);
                
                yield return null;
            }
            
            AbilityActivated?.Invoke(false);
            
            while (cooldown <= _cooldownDelay)
            {
                cooldown += Time.deltaTime;
                
                ProgressChanged?.Invoke(cooldown / _cooldownDelay, 1f);
                
                yield return null;
            }
            
            _isReady = true;
        }
    }
}