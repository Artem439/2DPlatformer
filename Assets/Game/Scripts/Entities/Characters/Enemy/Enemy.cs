using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Enemy.Attacker;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    [RequireComponent(typeof(PlayerDetector))]
    [RequireComponent(typeof(EnemyAttacker))]
    [RequireComponent(typeof(Patroller))]
    [RequireComponent(typeof(Pursuer))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        private PlayerDetector _playerDetector;
        private EnemyAttacker _enemyAttacker;
        
        private Patroller _patroller;
        private Pursuer _pursuer;
        
        private Transform _target;

        private void Awake()
        {
            _playerDetector = GetComponent<PlayerDetector>();
            _enemyAttacker = GetComponent<EnemyAttacker>();
            
            _patroller = GetComponent<Patroller>();
            _pursuer = GetComponent<Pursuer>();
        }

        private void Update()
        {
            _target = _playerDetector.DetectPlayer();
            
            if (_target == null)
            {
                EnablePatroller();
            }
            else
            {
                EnablePursuer(_target);
                _enemyAttacker.Attack();
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