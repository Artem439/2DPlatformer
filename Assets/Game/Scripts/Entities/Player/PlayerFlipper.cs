using System;
using Game.Scripts.Controls;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(InputReader))]
    public class PlayerFlipper : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private InputReader _inputReader;
        
        private Vector3 _direction;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void OnEnable()
        {
            _inputReader.Moved += OnMove;
        }

        private void OnDisable()
        {
            _inputReader.Moved -= OnMove;
        }

        private void Update()
        {
            FlipAxiosX();
        }

        private void FlipAxiosX()
        {
            if (_direction.x < 0)
                _spriteRenderer.flipX = true;
            
            _spriteRenderer.flipX = false;
        }
        
        private void OnMove(Vector3 direction)
        {
            _direction = direction;
        }
    }
}