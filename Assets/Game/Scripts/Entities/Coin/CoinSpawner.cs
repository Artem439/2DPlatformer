using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Entities.Coin
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private CoinsPool _coinsPool;
        [SerializeField] private List<Transform> _spawnPoints;
        
        private void Start()
        {
            Spawner();
        }
        
        private void Spawner()
        {
            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                Vector3 spawnPosition = _spawnPoints[i].position;
            
                Coin coin = _coinsPool.Get();
            
                coin.Reset(spawnPosition);
            
                coin.Released += OnReleased;
            }
        }

        private void OnReleased(Coin coin)
        {
            coin.Released -= OnReleased;
        
            _coinsPool.Release(coin);
        }
    }
}