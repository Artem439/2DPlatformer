using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private readonly int Speed = Animator.StringToHash(nameof(Speed));
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }
    }
}