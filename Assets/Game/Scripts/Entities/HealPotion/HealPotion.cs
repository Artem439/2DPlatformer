using System;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.HealPotion
{
    public class HealPotion : MonoBehaviour, ICollectable
    {
        public event Action<HealPotion> Released;

        public void Collect()
        {
            Release();
        }
        
        public void Reset(Vector2 position)
        {
            transform.rotation = Quaternion.identity;
            transform.position = position;
        }
    
        private void Release()
        {
            Released?.Invoke(this);
        }
    }
}