using Game.Scripts.Controls;
using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Player.Attacker
{
    [RequireComponent(typeof(DetectorBase))]
    [RequireComponent(typeof(InputReader))]
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private AbilityBase _ability;
        [SerializeField] private int _damage;
        [SerializeField] private float _abilityDamage;

        private DetectorBase _enemyDetector;
        private EnemyDetector _abilityDetector;
        private InputReader _inputReader;
        
        private IDamageable _enemy;

        private void OnValidate()
        {
            if (_damage <= 0)
                _damage = 1;
        }
        
        private void Awake()
        {
            _enemyDetector = GetComponent<DetectorBase>();
            _inputReader = GetComponent<InputReader>();
        }
        
        private void OnEnable()
        {
            _inputReader.AttackButtonClicked += Attack;
            _inputReader.AbilityButtonClicked += DealAbilityDamage;
            _playerAnimator.AttackHitFrameReached += DealDamage;
        }

        private void OnDisable()
        {
            _inputReader.AttackButtonClicked -= Attack;
            _inputReader.AbilityButtonClicked -= DealAbilityDamage;
            _playerAnimator.AttackHitFrameReached -= DealDamage;
        }
        
        private void Attack()
        {
            _playerAnimator.PlayAttack();
        }
        
        private void DealDamage()
        {
            _enemy = _enemyDetector.TryGetDamageable();
            
            if (_enemy == null)
                return;
            
            _enemy.TakeDamage(_damage);
        }

        private void DealAbilityDamage()
        {
            _ability.Activate();
        }
    }
}