using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class EnemyAnimator : AnimatorBase
    {
        private readonly int Speed = Animator.StringToHash("Speed");

        public void SetSpeed(float speed)
        {
            Animator.SetFloat(Speed, speed);
        }
    }
}