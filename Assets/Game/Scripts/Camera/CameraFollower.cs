using UnityEngine;

namespace Game.Scripts.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _smoothTime = 0.2f;
        [SerializeField] private Vector3 _offset;

        private Vector3 _velocity;

        private void LateUpdate()
        {
            Vector3 targetPosition = _target.position + _offset;
            targetPosition.z = transform.position.z;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        }
    }
}