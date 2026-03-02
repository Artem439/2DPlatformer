using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Enemy.Attacker;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private PlayerDetector _playerDetector;
        [SerializeField] private EnemyAttacker _enemyAttacker;

        [SerializeField] private Patroller _patroller;
        [SerializeField] private Pursuer _pursuer;

        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private Mover _mover;
        
        [SerializeField] private HealthBase _enemyHealth;
        
        private Rigidbody2D _rigidbody2D;
        private Collider2D[] _colliders;

        private Transform _target;
        private bool _isDead;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _colliders = GetComponentsInChildren<Collider2D>();
        }
        
        private void OnEnable()
        {
            _enemyHealth.CharacterDeath += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _enemyHealth.CharacterDeath -= OnCharacterDeath;
        }

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

        private void OnCharacterDeath()
        {
            enabled = false;
            
            _playerDetector.enabled = false;
            _enemyAttacker.enabled = false;
            _patroller.enabled = false;
            _pursuer.enabled = false;
            _mover.enabled = false;
            
            foreach (Collider2D collider in _colliders)
                collider.enabled = false;
            
            _rigidbody2D.simulated = false;
            
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