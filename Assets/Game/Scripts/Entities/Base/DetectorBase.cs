using System;
using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    public class DetectorBase : MonoBehaviour
    {
        private const int SizeDivider = 2;
        
        [SerializeField] protected Transform _attackPoint;
        [SerializeField] protected Vector2 _size;
        [SerializeField] protected LayerMask _layer;
        
        private readonly Collider2D[] _overlapResults = new Collider2D[10];
        private readonly Collider2D[] _damageables = new Collider2D[10];
        
        public IDamageable TryGetDamageable()
        {
            Vector2 center = _attackPoint.position;
            Vector2 pointA = center - _size / SizeDivider;
            Vector2 pointB = center + _size / SizeDivider;

            int hitCount = Physics2D.OverlapAreaNonAlloc(pointA, pointB, _overlapResults, _layer);

            for (int i = 0; i < hitCount; i++)
            {
                if (_overlapResults[i] != null && _overlapResults[i].TryGetComponent(out IDamageable damageable))
                {
                    return damageable;
                }
            }
            
            return null;
        }
        
        public Collider2D[] TryGetAllDamageables()
        {
            Vector2 center = _attackPoint.position;
            Vector2 pointA = center - _size / SizeDivider;
            Vector2 pointB = center + _size / SizeDivider;

            int hitCount = Physics2D.OverlapAreaNonAlloc(pointA, pointB, _overlapResults, _layer);

            Array.Clear(_damageables, 0, _damageables.Length);
            
            for (int i = 0; i < hitCount; i++)
            {
                if (_overlapResults[i] != null)
                    _damageables[i] = _overlapResults[i];
            }
            
            return _damageables;
        }
    }
}