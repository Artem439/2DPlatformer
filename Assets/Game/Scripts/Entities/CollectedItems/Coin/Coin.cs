using System;
using Game.Scripts.Entities.Base;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Coin
{
    public class Coin : MonoBehaviour, ICollectable, ISpawnable<Coin>
    {
        private ISpawnable<Coin> spawnableImplementation;
        public event Action<Coin> Released;

        public void Collect()
        {
            Release();
        }
        
        public void Reset(Vector2 position)
        {
            transform.rotation = Quaternion.identity;
            transform.position = position;
        }
    
        public void Release()
        {
            Released?.Invoke(this);
        }
    }
}