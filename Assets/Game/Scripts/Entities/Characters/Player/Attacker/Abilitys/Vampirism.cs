using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Player.Attacker;
using UnityEngine;

namespace Game.Scripts.Entities.Characters.Player.Attacker.Abilitys
{
    [RequireComponent(typeof(HealthBase))]
    public class Vampirism : AbilityBase
    {
        [SerializeField] private EnemyDetector _enemyDetector;
        
        private IDamageable _enemy;
        private HealthBase _healthBase;

        private void Awake()
        {
            _healthBase = GetComponent<HealthBase>();
        }
        
        protected override void Execute()
        {
            _enemy = _enemyDetector.TryGetNearestDamageable();

            if (_enemy == null)
                return;
            
            _enemy.TakeDamage(_abilityDamage);
            
            _healthBase.Heal(_abilityDamage);
        }
    }
}