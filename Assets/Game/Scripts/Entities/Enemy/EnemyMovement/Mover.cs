    using Game.Scripts.Entities.Utils;
    using UnityEngine;

    namespace Game.Scripts.Entities.Enemy
    {
        [RequireComponent(typeof(Flipper))]
        public class Mover : MonoBehaviour
        {
            [SerializeField] private EnemyAnimator _animator;
            
            [SerializeField] private float _speed = 2f;
            
            private Vector3 _direction;

            private Flipper _flipper;

            private void Awake()
            {
                _flipper = GetComponent<Flipper>();
            }

            public void Move(Vector3 direction)
            {
                Vector3 nextPosition = Vector3.MoveTowards( transform.position, direction, _speed * Time.deltaTime);

                nextPosition.y = transform.position.y;
                transform.position = nextPosition;
                
                _direction = direction - transform.position;
                
                _flipper.Flip(_direction);
                
                _animator.SetSpeed(Mathf.Abs(_direction.x));
            }
        }
    }