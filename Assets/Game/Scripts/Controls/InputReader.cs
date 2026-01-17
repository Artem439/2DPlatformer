using System;
using UnityEngine;

namespace Game.Scripts.Controls
{
    public class InputReader : MonoBehaviour
    {
        private const int JumpButton = 32;
        
        private const string Horizontal = "Horizontal";

        private Vector3 _direction;
        
        public event Action<Vector3> Moved;
        public event Action JumpButtonClicked;

        private void Update()
        {
            _direction = new Vector3(Input.GetAxisRaw(Horizontal), 0f, 0f);
            
            if (_direction.sqrMagnitude > 0f)
                Moved?.Invoke(_direction);

            if (Input.GetKey((KeyCode)JumpButton))
                JumpButtonClicked?.Invoke();
        }
    }
}