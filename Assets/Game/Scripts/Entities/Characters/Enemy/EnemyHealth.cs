using System;
using Game.Scripts.Entities.Base;

namespace Game.Scripts.Entities.Enemy
{
    public class EnemyHealth : HealthBase
    {
        public event Action OnEnemyDeath;

        private void Update()
        {
            if (_health <= 0)
                OnEnemyDeath?.Invoke();
        }
    }
}