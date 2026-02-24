using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class Pursuer : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        
        private Transform _target;

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