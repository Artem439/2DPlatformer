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
        [SerializeField] private int _damage;

        private DetectorBase _enemyDetector;
        private InputReader _inputReader;
        
        private IDamageable _enemy;
        
        private void Awake()
        {
            _enemyDetector = GetComponent<DetectorBase>();
            _inputReader = GetComponent<InputReader>();
        }
        
        private void OnEnable()
        {
            _inputReader.AttackButtonClicked += Attack;
        }

        private void OnDisable()
        {
            _inputReader.AttackButtonClicked -= Attack;
        }
        
        private void Attack()
        {
            _enemy = _enemyDetector.TryGetDamageable();
            
            _playerAnimator.PlayAttack();

            if (_enemy == null)
                return;
            
            _enemy.TakeDamage(_damage);
        }
    }
}