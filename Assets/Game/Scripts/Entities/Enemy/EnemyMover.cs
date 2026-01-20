using System.Collections.Generic;
using Game.Scripts.Entities.Utils;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    [RequireComponent(typeof(Flipper))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private List<Transform> _targetPoints;
        [SerializeField] private EnemyAnimator _animator;
        
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _reachDistance = 0.2f;
        
        private Vector3 _targetPosition;
        private Vector3 _direction;

        private Flipper _flipper;
        
        private int _targetPositionIndex;

        private void Awake()
        {
            _flipper = GetComponent<Flipper>();
        }

        private void Start()
        {
            _targetPositionIndex = 0;
            SetTargetPosition();
        }

        private void Update()
        {
            UpdateTarget();

            Move();
        }

        private void Move()
        {
            Vector3 nextPosition = Vector3.MoveTowards( transform.position, _targetPosition, _speed * Time.deltaTime);

            nextPosition.y = transform.position.y;
            transform.position = nextPosition;
            
            _direction = _targetPosition - transform.position;
            
            _flipper.Flip(_direction);
            
            _animator.SetSpeed(Mathf.Abs(_direction.x));
        }

        private void UpdateTarget()
        {
            Vector2 currentXY = new Vector2(transform.position.x, transform.position.y);
            Vector2 targetXY = new Vector2(_targetPosition.x, _targetPosition.y);

            if (Vector2.Distance(currentXY, targetXY) <= _reachDistance)
            {
                _targetPositionIndex = (_targetPositionIndex + 1) % _targetPoints.Count;
                SetTargetPosition();
            }
        }

        private void SetTargetPosition()
        {
            Vector3 pointPosition = _targetPoints[_targetPositionIndex].position;

            _targetPosition = new Vector3(pointPosition.x, transform.position.y, pointPosition.z);
        }
    }
}