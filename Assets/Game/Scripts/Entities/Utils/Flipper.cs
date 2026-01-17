using UnityEngine;

namespace Game.Scripts.Entities.Utils
{
    public class Flipper : MonoBehaviour
    {
        public void Flip(Vector2 direction)
        {
            if (direction.x == 0)
                return;

            float yRotation = direction.x > 0 ? 0f : 180f;
            
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        }
    }
}