using Game.Scripts.Entities.Player;
using UnityEngine;

namespace Game.Scripts.Entities.CollectedItems.HealPotion
{
    public class HealPotion : CollectableItem
    {
        [SerializeField] private float _healAmount;
        
        public override void Collect(Collector collector)
        {
            collector.Health.Heal(_healAmount);

            OnReleased();
        }
    }
}