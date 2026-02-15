using Game.Scripts.Entities.Base;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        public void TakeDamage(float damage)
        {
            Debug.Log("Player take damage:  " + damage);
        }
    }
}