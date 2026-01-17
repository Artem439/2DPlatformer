using Game.Scripts.Controls;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(GroundDetector))]
    [RequireComponent(typeof(InputReader))]
    public class PlayerJumper : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private float _jumpHeight = 0.05f;
        
        private Rigidbody2D _rigidbody2D;
        private GroundDetector _groundDetector;
        private InputReader _inputReader;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _groundDetector = GetComponent<GroundDetector>();
            _inputReader = GetComponent<InputReader>();
        }

        private void OnEnable()
        {
            _inputReader.JumpButtonClicked += Jump;
        }

        private void OnDisable()
        {
            _inputReader.JumpButtonClicked -= Jump;
        }
        
        private void Jump()
        {
            if ( _groundDetector.IsGrounded && Mathf.Abs(_rigidbody2D.velocity.y) < _jumpHeight)
                _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }
}