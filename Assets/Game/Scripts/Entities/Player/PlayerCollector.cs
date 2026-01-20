using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    public class PlayerCollector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ICollectable collectable))
            {
                collectable.Collect();
            }
        }
    }
}