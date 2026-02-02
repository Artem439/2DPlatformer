using System;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class PlayerDetector : MonoBehaviour
    {
        public Action<Transform> OnPlayerEntered;
        public Action OnPlayerOut;
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player.Player player))
            {
                OnPlayerEntered?.Invoke(player.transform);
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player.Player _))
            {
                OnPlayerOut?.Invoke();
            }
        }
    }
}