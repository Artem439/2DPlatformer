using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy.Attacker
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private int _damage;
        
        [SerializeField] private PlayerDetector _playerDetector;
        
        private IDamageable _player;
        
        [SerializeField] private float _attackCooldown = 0.6f;

        private float _nextAttackTime;
        private bool _damageAppliedThisAttack;

        private void OnEnable()
        {
            _enemyAnimator.AttackHitFrameReached += ApplyDamageOnHitFrame;
        }

        private void OnDisable()
        {
            _enemyAnimator.AttackHitFrameReached -= ApplyDamageOnHitFrame;
        }

        public void TryStartAttack()
        {
            if (_enemyAnimator == null || _playerDetector == null)
                return;

            if (Time.time < _nextAttackTime)
                return;

            if (_playerDetector.TryGetDamageable() == null)
                return;

            _nextAttackTime = Time.time + _attackCooldown;
            _damageAppliedThisAttack = false;

            _enemyAnimator.PlayAttack();
        }

        private void ApplyDamageOnHitFrame()
        {
            if (_damageAppliedThisAttack)
                return;

            _player = _playerDetector.TryGetDamageable();
            
            if (_player == null)
                return;

            _player.TakeDamage(_damage);
            _damageAppliedThisAttack = true;
        }
    }
}