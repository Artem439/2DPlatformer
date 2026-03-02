using Game.Scripts.Controls;
using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private HealthBase _playerHealth;
        [SerializeField] private InputReader _inputReader;

        private Rigidbody2D _rigidbody2D;
        private Collider2D[] _colliders;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _colliders = GetComponentsInChildren<Collider2D>();
        }

        private void OnEnable()
        {
            _playerHealth.CharacterDeath += OnPlayerDeath;
        }

        private void OnDisable()
        {
            _playerHealth.CharacterDeath -= OnPlayerDeath;
        }

        private void OnPlayerDeath()
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