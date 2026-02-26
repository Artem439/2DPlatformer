using System;
using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Enemy.Attacker;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private  float _health;
        
        [SerializeField] private PlayerDetector _playerDetector;
        [SerializeField] private EnemyAttacker _enemyAttacker;
        
        [SerializeField] private Patroller _patroller;
        [SerializeField] private Pursuer _pursuer;
        
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private Mover _mover;
        
        private Transform _target;
        private bool _isDead;

        private void Start()
        {
            _patroller.enabled = true;
            _pursuer.enabled = false;
        }

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

        public void TakeDamage(float damage)
        {
            if (_isDead)
                return;

            _health -= damage;

            if (_health > 0)
                return;

            _isDead = true;

            enabled = false;
            
            _playerDetector.enabled = false;
            _enemyAttacker.enabled = false;
            _patroller.enabled = false;
            _pursuer.enabled = false;
            _mover.enabled = false;

            foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
                collider.enabled = false;

            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            
            rigidbody2D.simulated = false;

            _enemyAnimator.PlayDeath();
        }

        public void DeathEnd()
        {
            Destroy(gameObject);
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