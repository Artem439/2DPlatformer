using System;
using UnityEngine;

namespace Game.Scripts.Entities.Coin
{
    public class Coin : MonoBehaviour
    {
        public event Action<Coin> Released;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player.Player _) == false)
                return;
            
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