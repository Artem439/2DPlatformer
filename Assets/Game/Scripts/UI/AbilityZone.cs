using System;
using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.UI
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AbilityZone : MonoBehaviour
    {
        [SerializeField] private AbilityBase _abilityBase;
        
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _abilityBase.AbilityActivated += OnActiveZone;
        }

        private void OnDisable()
        {
            _abilityBase.AbilityActivated -= OnActiveZone;
        }

        private void OnActiveZone(bool active)
        {
            _spriteRenderer.enabled = active;
        }
    }
}