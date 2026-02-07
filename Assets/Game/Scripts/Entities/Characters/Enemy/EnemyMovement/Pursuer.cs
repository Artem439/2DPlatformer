using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    [RequireComponent(typeof(Mover))]
    public class Pursuer : MonoBehaviour
    {
        [SerializeField] private PlayerDetector _playerDetector;

        private Mover _mover;
        
        private Transform _target;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void Update()
        {
            if (_target == null)
                return;
            
            _mover.Move(_target.position);
        }
        
        public void SetTarget(Transform playerPosition)
        {
            _target = playerPosition;
        }

        public void ClearTarget()
        {
            _target = null;
        }
    }
}