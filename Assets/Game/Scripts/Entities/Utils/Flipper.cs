using UnityEngine;

namespace Game.Scripts.Entities.Utils
{
    public class Flipper : MonoBehaviour
    {
        private const float FlipDeadZone = 0.01f;
        
        private const float ToRight = 0f;
        private const float ToLeft = 180f;

        private bool _facingRight;
        
        public void Flip(Vector2 direction)
        {
            if (Mathf.Abs(direction.x) < FlipDeadZone)
               return;

            if (direction.x > 0 && _facingRight == false)
            {
                transform.rotation = Quaternion.Euler(0f, ToRight, 0f);
                
                _facingRight = true;
            }
            else if (direction.x < 0 && _facingRight)
            {
                transform.rotation = Quaternion.Euler(0f, ToLeft, 0f);
                
                _facingRight = false;
            }
        }
    }
}