using Game.Scripts.Controls;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(InputReader))]
    public class PlayerJumper : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private float _jumpHeight = 0.05f;
        
        private Rigidbody2D _rigidbody2D;
        private InputReader _inputReader;
        
        private Vector3 _direction;
        
        private bool _jumpButtonClicked;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _inputReader = GetComponent<InputReader>();
        }
        
        private void OnEnable()
        {
            _inputReader.JumpButtonClicked += OnJumpButtonClicked;
        }

        private void OnDisable()
        {
            _inputReader.JumpButtonClicked -= OnJumpButtonClicked;
        }

        private void Update()
        {
            Jump();
        }
        
        private void Jump()
        {
            if (_jumpButtonClicked && Mathf.Abs(_rigidbody2D.velocity.y) < _jumpHeight)
                _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
        
        private void OnJumpButtonClicked()
        {
            _jumpButtonClicked = true;
        }
    }
}