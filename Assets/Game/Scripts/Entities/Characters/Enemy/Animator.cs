using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class Animator : MonoBehaviour
    {
        private readonly int Speed = UnityEngine.Animator.StringToHash(nameof(Speed));
        
        private UnityEngine.Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<UnityEngine.Animator>();
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }
    }
}