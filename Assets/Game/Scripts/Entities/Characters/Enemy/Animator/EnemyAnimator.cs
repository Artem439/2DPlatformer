using System;
using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class EnemyAnimator : AnimatorBase
    {
        private readonly int Speed = Animator.StringToHash("Speed");
        private readonly int Attack = Animator.StringToHash("Attack");
        private readonly int Death = Animator.StringToHash("Death");

        public event Action AttackHitFrameReached;
        
        public void SetSpeed(float speed)
        {
            Animator.SetFloat(Speed, speed);
        }

        public void PlayAttack()
        {
            Animator.SetTrigger(Attack);
        }
        
        public void AttackHitFrame()
        {
            AttackHitFrameReached?.Invoke();
        }
        
        public void PlayDeath()
        {
            Animator.SetTrigger(Death);
        }
    }
}