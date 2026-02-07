using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    [RequireComponent(typeof(Mover))]
    public class Patroller : MonoBehaviour
    {
        [SerializeField] private List<Transform> _targetPoints;
        
        [SerializeField] private float _reachDistance = 0.2f;
        
        private Mover _mover;
        
        private Vector3 _targetPosition;
        
        private int _targetPositionIndex;
        
        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void Start()
        {
            _targetPositionIndex = 0;
            SetTargetPosition();
        }
        
        private void Update()
        {
            UpdateTarget();
            
            _mover.Move(_targetPosition);
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