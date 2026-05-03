using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Characters.Player.Interaction
{
    public class Collector : MonoBehaviour
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