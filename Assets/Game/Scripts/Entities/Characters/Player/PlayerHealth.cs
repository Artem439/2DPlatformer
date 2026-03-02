using System;
using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    public class PlayerHealth : HealthBase
    {
        public event Action OnPlayerDeath;

        private void Update()
        {
            if (_health <= 0)
                OnPlayerDeath?.Invoke();
        }
    }
}