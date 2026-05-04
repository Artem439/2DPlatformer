using System;
using UnityEngine;

namespace Game.Scripts.Controls
{
    public class InputReader : MonoBehaviour
    {
        private const KeyCode JumpButton = KeyCode.Space;
        private const KeyCode AbilityButton = KeyCode.E;
        private const KeyCode MouseLeftButton = KeyCode.Mouse0;
        
        private const string Horizontal = "Horizontal";

        private Vector3 _direction;
        
        public event Action<Vector3> Moved;
        public event Action JumpButtonClicked;
        public event Action AttackButtonClicked;
        public event Action AbilityButtonClicked;

        private void Update()
        {
            _direction.x = Input.GetAxisRaw(Horizontal);

            Moved?.Invoke(_direction);

            if (Input.GetKeyDown(JumpButton))
                JumpButtonClicked?.Invoke();
            
            if (Input.GetKeyDown(MouseLeftButton))
                AttackButtonClicked?.Invoke();
            
            if (Input.GetKeyDown(AbilityButton))
                AbilityButtonClicked?.Invoke();
        }

        public void Disable()
        {
            enabled = false;
        }
    }
}