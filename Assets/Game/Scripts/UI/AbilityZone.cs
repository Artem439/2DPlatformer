using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Player.Attacker;
using UnityEngine;

namespace Game.Scripts.UI
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AbilityZone : MonoBehaviour
    {
        [SerializeField] private AbilityBase _abilityBase;
        [SerializeField] private EnemyDetector _enemyDetector;
        
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            Vector2 parentScale = transform.parent.lossyScale;
            transform.localScale = new Vector2(
                _enemyDetector.Size.x / parentScale.x,
                _enemyDetector.Size.y / parentScale.y
            );
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