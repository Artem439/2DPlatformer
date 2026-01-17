using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private float _checkDistance = 0.1f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _rayOrigin;

        public bool IsGrounded { get; private set; }
        
        private void Update()
        {
            Detect();
        }

        private void Detect()
        {
            RaycastHit2D hit = Physics2D.Raycast(_rayOrigin.position, Vector2.down, _checkDistance, _groundLayer);
        
            IsGrounded = hit.collider != null;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = IsGrounded ? Color.green : Color.red;
            Gizmos.DrawLine(_rayOrigin.position, transform.position + Vector3.down * _checkDistance);
        }
#endif
    }
}