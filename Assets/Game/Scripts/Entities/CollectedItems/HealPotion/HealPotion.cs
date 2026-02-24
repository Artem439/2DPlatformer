using System;
using Game.Scripts.Entities.Base;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.HealPotion
{
    public class HealPotion : MonoBehaviour, ICollectable, ISpawnable<HealPotion>
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
    
        public void Release()
        {
            Released?.Invoke(this);
        }
    }
}