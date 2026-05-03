using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.CollectedItems.HealPotion
{
    public class HealPotion : CollectableItem
    {
        [SerializeField] private HealthBase _health;
        [SerializeField] private float _healAmount;
    
        public void Collect()
        {
            _health.Heal(_healAmount);
        }
    }
}