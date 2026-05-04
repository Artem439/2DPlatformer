using System;
using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Player;
using UnityEngine;

namespace Game.Scripts.Entities.CollectedItems
{
    public class CollectableItem : MonoBehaviour, ICollectable, ISpawnable<CollectableItem>
    {
        public event Action<CollectableItem> Released;

        public virtual void Collect(Collector collector)
        {
            OnReleased();
        }
        
        public void Reset(Vector2 position)
        {
            transform.rotation = Quaternion.identity;
            transform.position = position;
        }
        
        protected void OnReleased()
        {
            Released?.Invoke(this);
        }
    }
}