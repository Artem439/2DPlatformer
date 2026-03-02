using Game.Scripts.Controls;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private  InputReader _inputReader;

        private Rigidbody2D _rigidbody2D;
        private Collider2D[] _colliders;
        
        private bool _isDead;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _colliders = GetComponentsInChildren<Collider2D>();
        }

        private void OnEnable()
        {
            _playerHealth.OnPlayerDeath += PlayerDeath;
        }

        private void OnDisable()
        {
            _playerHealth.OnPlayerDeath -= PlayerDeath;
        }

        private void PlayerDeath()
        {
            enabled = false;
            
            _inputReader.enabled = false;

            foreach (Collider2D collider in _colliders)
                collider.enabled = false;
            
            _rigidbody2D.simulated = false;

            _playerAnimator.PlayDeath();
        }
    }
}