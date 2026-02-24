using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    public class DetectorBase : MonoBehaviour
    {
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private Vector2 _size;
        [SerializeField] protected LayerMask _layer;
        
        private readonly Collider2D[] _overlapResults = new Collider2D[10];
        
        public IDamageable TryGetDamageable()
        {
            Vector2 center = _attackPoint.position;
            Vector2 pointA = center - _size / 2;
            Vector2 pointB = center + _size / 2;

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
    }
}