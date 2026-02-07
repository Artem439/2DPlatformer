using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    [RequireComponent(typeof(PlayerDetector))]
    [RequireComponent(typeof(Patroller))]
    [RequireComponent(typeof(Pursuer))]
    public class Enemy : MonoBehaviour
    {
        private PlayerDetector _playerDetector;
        
        private Patroller _patroller;
        private Pursuer _pursuer;

        private void Awake()
        {
            _playerDetector = GetComponent<PlayerDetector>();
            
            _patroller = GetComponent<Patroller>();
            _pursuer = GetComponent<Pursuer>();
        }

        private void Update()
        {
            if (_playerDetector.DetectPlayer() == null)
            {
                Debug.Log("Player is not detected");
                EnablePatroller();
            }
            else
            {
                Debug.Log("Player is detected");
                EnablePursuer(_playerDetector.DetectPlayer());
            }
        }

        private void Start()
        {
            _patroller.enabled = true;
            _pursuer.enabled = false;
        }

        private void EnablePursuer(Transform other)
        {
            _pursuer.enabled = true;
            _patroller.enabled = false;
            
            _pursuer.SetTarget(other);
        }

        private void EnablePatroller()
        {
            _patroller.enabled = true;
            _pursuer.enabled = false;
            
            _pursuer.ClearTarget();
        }
    }
}