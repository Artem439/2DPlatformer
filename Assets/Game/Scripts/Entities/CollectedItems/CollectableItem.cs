using System;
using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.CollectedItems
{
    public class CollectableItem : MonoBehaviour, ICollectable, ISpawnable<CollectableItem>
    {
        public event Action<CollectableItem> Released;

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