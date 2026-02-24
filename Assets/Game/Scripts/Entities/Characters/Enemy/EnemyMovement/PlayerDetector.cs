using Game.Scripts.Entities.Base;
using UnityEngine;
using System;

namespace Game.Scripts.Entities.Enemy
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private Transform _rayOrigin;
        
        [SerializeField] private float _rayDistance = 1f;
        
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private Vector2 _size;
        
        private readonly Collider2D[] _overlapResults = new Collider2D[10];
        
        public Transform TryGetDetectedPlayerTransform()
        {
            Vector2 direction = transform.right;
            
            RaycastHit2D hit = Physics2D.Raycast(_rayOrigin.position, direction, _rayDistance, _playerLayer);
            
            if (hit.collider == null)
                return null;
            
            if (hit.collider.TryGetComponent(out Player.Player player))
                return player.transform;
            else
                return null;
        }
        
        public IDamageable TryGetDamageable()
        {
            Vector2 center = _attackPoint.position;
            Vector2 pointA = center - _size / 2;
            Vector2 pointB = center + _size / 2;

            int hitCount = Physics2D.OverlapAreaNonAlloc(pointA, pointB, _overlapResults, _playerLayer);

            for (int i = 0; i < hitCount; i++)
            {
                if (_overlapResults[i] != null && _overlapResults[i].TryGetComponent(out IDamageable damageable))
                {
                    return damageable;
                }
            }
            
            return null;
        }
    }
}