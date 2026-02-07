using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Entities.HealPotion
{
    public class PotionSpawner : MonoBehaviour
    {
        [SerializeField] private PotionsPool _potionsPool;
        [SerializeField] private List<Transform> _spawnPoints;
        
        private void Start()
        {
            Spawn();
        }
        
        private void Spawn()
        {
            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                Vector3 spawnPosition = _spawnPoints[i].position;
            
                HealPotion potion = _potionsPool.Get();
            
                potion.Reset(spawnPosition);
            
                potion.Released += OnReleased;
            }
        }

        private void OnReleased(HealPotion potion)
        {
            potion.Released -= OnReleased;
        
            _potionsPool.Release(potion);
        }
    }
}