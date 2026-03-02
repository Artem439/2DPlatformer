using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorBase : MonoBehaviour
    {
        protected Animator Animator;

        private void Awake()
        {
            Animator = GetComponent<Animator>();
        }
    }
}