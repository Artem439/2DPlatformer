using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    public abstract class SpawnerBase<T> : MonoBehaviour where T : Component, ISpawnable<T>
    {
        [SerializeField] private PoolBase<T> _entitiesPool;
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
            
                T entity = _entitiesPool.Get();
            
                entity.Reset(spawnPosition);
            
                entity.Released += OnReleased;
            }
        }

        private void OnReleased(T entity)
        {
            entity.Released -= OnReleased;
        
            _entitiesPool.Release(entity);
        }
    }
}