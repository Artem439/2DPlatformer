using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _rayOrigin;
        
        [SerializeField] private float _rayDistance = 0.1f;
        
        public bool IsGrounded()
        {
            return Physics2D.Raycast(_rayOrigin.position, Vector2.down, _rayDistance, _groundLayer);
        }
    }
}