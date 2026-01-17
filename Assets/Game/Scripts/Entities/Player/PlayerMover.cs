using Game.Scripts.Controls;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    [RequireComponent(typeof(InputReader))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;
        
        private InputReader _inputReader;
        
        private Vector3 _direction;
        
        private bool _jumpButtonClicked;

        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
        }
        
        private void OnEnable()
        {
            _inputReader.Moved += OnMove;
        }

        private void OnDisable()
        {
            _inputReader.Moved -= OnMove;
        }

        private void Update()
        {
            Move();
        }
        
        private void Move()
        {
            transform.position += new Vector3(_direction.x, 0f, 0f ) * (_moveSpeed * Time.deltaTime);
        }
        
        private void OnMove(Vector3 direction)
        {
            _direction = direction;
        }
    }
}