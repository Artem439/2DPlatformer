using System;
using UnityEngine;

namespace Game.Scripts.Controls
{
    public class InputReader : MonoBehaviour
    {
        private const KeyCode JumpButton = KeyCode.Space;
        
        private const string Horizontal = "Horizontal";

        private Vector3 _direction;
        
        public event Action<Vector3> Moved;
        public event Action JumpButtonClicked;

        private void Update()
        {
            _direction.x = Input.GetAxisRaw(Horizontal);

            Moved?.Invoke(_direction);

            if (Input.GetKeyDown(JumpButton))
                JumpButtonClicked?.Invoke();
        }
    }
}