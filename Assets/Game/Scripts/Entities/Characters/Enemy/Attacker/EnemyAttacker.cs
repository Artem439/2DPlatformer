using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy.Attacker
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private Vector2 _size;
        [SerializeField] private LayerMask _layer;
        [SerializeField] private int _damage;
        
        private readonly Collider2D[] _overlapResults = new Collider2D[10];
        
        private bool _hasHit = false;
        
        public void Attack()
        {
            Vector2 center = _attackPoint.position;
            
            Vector2 pointA = center - _size / 2;
            Vector2 pointB = center + _size / 2;

            int hitCount = Physics2D.OverlapAreaNonAlloc(pointA, pointB, _overlapResults, _layer);

            _hasHit = false;

            for (int i = 0; i < hitCount; i++)
            {
                if (_overlapResults[i] != null && _overlapResults[i].TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(_damage);
                    _hasHit = true;
                }
            }
            
            _enemyAnimator.SetIsDamageable(_hasHit);
        }
        
        private void OnDrawGizmosSelected()
        {
            if (_attackPoint == null)
                return;

            Gizmos.color = Color.red;

            Vector2 center = _attackPoint.position;
            Gizmos.DrawWireCube(center, _size);
        }

    }
}