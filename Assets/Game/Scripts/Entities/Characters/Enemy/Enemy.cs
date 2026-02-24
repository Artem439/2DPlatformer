using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Enemy.Attacker;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private PlayerDetector _playerDetector;
        [SerializeField] private EnemyAttacker _enemyAttacker;
        
        [SerializeField] private Patroller _patroller;
        [SerializeField] private Pursuer _pursuer;
        
        private Transform _target;

        private void Update()
        {
            _target = _playerDetector.TryGetDetectedPlayerTransform();
            
            if (_target == null)
            {
                EnablePatroller();
            }
            else
            {
                EnablePursuer(_target);
                _enemyAttacker.TryStartAttack();
            }
        }

        private void Start()
        {
            _patroller.enabled = true;
            _pursuer.enabled = false;
        }

        public void TakeDamage(float damage)    
        {
            Debug.Log("Enemy take damage:  " + damage);
        }

        private void EnablePursuer(Transform other)
        {
            _pursuer.enabled = true;
            _patroller.enabled = false;
            
            _pursuer.SetTarget(other);
        }

        private void EnablePatroller()
        {
            _patroller.enabled = true;
            _pursuer.enabled = false;
            
            _pursuer.ClearTarget();
        }
    }
}