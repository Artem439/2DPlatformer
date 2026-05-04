using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class AbilityBarChanger : BaseBarChanger
    {
        [SerializeField] private AbilityBase _ability;
        
        private void OnEnable()
        {
            _ability.ProgressChanged += OnProgressChanged;
        }

        private void OnDisable()
        {
            _ability.ProgressChanged -= OnProgressChanged;
        }
        
        private void OnProgressChanged(float currentProgress, float maxProgress)
        {
            UpdateBar(currentProgress, maxProgress);
        }
    }
}