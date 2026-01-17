using Game.Scripts.Controls;
using Game.Scripts.Entities.Utils;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    [RequireComponent(typeof(InputReader))]
    [RequireComponent(typeof(Flipper))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;
        
        private InputReader _inputReader;
        private Flipper _flipper;
        
        private Vector3 _direction;
        
        private bool _jumpButtonClicked;

        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
            _flipper = GetComponent<Flipper>();
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
            transform.position += Vector3.right * (_direction.x * _moveSpeed * Time.deltaTime);
            
            _flipper.Flip(_direction);
        }
        
        private void OnMove(Vector3 direction)
        {
            _direction = direction;
        }
    }
}