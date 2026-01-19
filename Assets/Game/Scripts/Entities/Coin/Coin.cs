using System;
using UnityEngine;

namespace Game.Scripts.Entities.Coin
{
    public class Coin : MonoBehaviour
    {
        private bool _isTouched = false;
    
        public event Action<Coin> Released;
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Player.Player _) == false)
                return;
        
            if (_isTouched)
                return;
        
            _isTouched = true;
            
            Release();
        }

        public void Reset(Vector2 position)
        {
            _isTouched = false;
            transform.rotation = Quaternion.identity;
            transform.position = position;
        }
    
        private void Release()
        {
            Released?.Invoke(this);
        }
    }
}