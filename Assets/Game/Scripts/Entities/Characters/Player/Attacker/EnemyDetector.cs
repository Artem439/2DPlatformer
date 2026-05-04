using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Player.Attacker
{
    public class EnemyDetector : DetectorBase
    {
        public IDamageable TryGetNearestDamageable()
        {
            IDamageable nearest = null;
            float minDistance = float.MaxValue;
            
            Collider2D[] damageables = TryGetAllDamageables();

            for (int i = 0; i < damageables.Length; i++)
            {
                if (damageables[i] == null)
                    continue;
                
                float distance = Vector2.Distance(_attackPoint.position, damageables[i].transform.position);
                
                if (distance < minDistance)
                {
                    minDistance = distance;
                    
                    if (damageables[i].TryGetComponent(out IDamageable damageable))
                        nearest = damageable;
                }
            }
            
            return nearest;
        }
    }
}