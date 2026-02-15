using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private Transform _rayOrigin;
        
        [SerializeField] private float _rayDistance = 1f;
        
        public Transform DetectPlayer()
        {
            Vector2 direction = transform.right;
            
            RaycastHit2D hit = Physics2D.Raycast(_rayOrigin.position, direction, _rayDistance, _playerLayer);
            
            if (hit.collider == null)
                return null;
            
            if (hit.collider.TryGetComponent(out Player.Player player))
                return player.transform;
            else
                return null;
        }
    }
}