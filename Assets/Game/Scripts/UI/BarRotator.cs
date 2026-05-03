using UnityEngine;

namespace Game.Scripts.UI
{
    public class BarRotator : MonoBehaviour
    {
        [SerializeField] private Canvas _statsCanvas;

        private void LateUpdate()
        {
            _statsCanvas.transform.rotation = Quaternion.identity;
        }
    }
}