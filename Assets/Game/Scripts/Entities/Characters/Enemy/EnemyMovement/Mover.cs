    using Game.Scripts.Entities.Utils;
    using UnityEngine;

    namespace Game.Scripts.Entities.Enemy
    {
        public class Mover : MonoBehaviour
        {
            [SerializeField] private EnemyAnimator _enemyAnimator;
            [SerializeField] private Flipper _flipper;
            [SerializeField] private float _speed = 2f;
            
            private Vector3 _direction;

            public void Move(Vector3 direction)
            {
                Vector3 nextPosition = Vector3.MoveTowards( transform.position, direction, _speed * Time.deltaTime);

                nextPosition.y = transform.position.y;
                transform.position = nextPosition;
                
                _direction = direction - transform.position;
                
                _flipper.Flip(_direction);
                
                _enemyAnimator.SetSpeed(Mathf.Abs(_direction.x));
            }
        }
    }