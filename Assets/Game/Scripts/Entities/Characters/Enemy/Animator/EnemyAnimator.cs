using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class EnemyAnimator : AnimatorBase
    {
        private readonly int Speed = Animator.StringToHash("Speed");
        private readonly int isDamageable = Animator.StringToHash("IsDamageable");

        public void SetSpeed(float speed)
        {
            Animator.SetFloat(Speed, speed);
        }

        public void SetIsDamageable(bool damageable)
        {
            Animator.SetBool(isDamageable, damageable);
        }
    }
}