using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _rayOrigin;
        
        [SerializeField] private float _checkDistance = 0.1f;

        private bool _isGrounded;
        
        public bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(_rayOrigin.position, Vector2.down, _checkDistance, _groundLayer);
        
            _isGrounded = hit.collider != null;
            
            return _isGrounded;
        }
    }
}