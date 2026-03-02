using System;
using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.CollectedItems
{
    public class CollectibleItem : MonoBehaviour, ICollectable, ISpawnable<CollectibleItem>
    {
        public event Action<CollectibleItem> Released;

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