using Game.Scripts.Controls;
using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private  float _health;
        [SerializeField] private PlayerAnimator _playerAnimator;
        
        [SerializeField] private  InputReader _inputReader;
        
        private bool _isDead;
        
        public void TakeDamage(float damage)
        {
            if (_isDead)
                return;

            _health -= damage;

            if (_health > 0)
                return;

            _isDead = true;

            enabled = false;
            
            _inputReader.enabled = false;

            foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
                collider.enabled = false;

            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            
            rigidbody2D.simulated = false;

            _playerAnimator.PlayDeath();
        }
    }
}