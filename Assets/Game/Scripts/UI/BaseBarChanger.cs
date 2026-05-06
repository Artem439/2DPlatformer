using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Entities.Base
{
    [RequireComponent(typeof(Slider))]
    public class BaseBarChanger : MonoBehaviour
    {
        private const float Epsilon = 0.00001f;
        
        [SerializeField] protected float _speed;
        
        private Slider _slider;
        private Coroutine _coroutine;
        
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
        
        protected void UpdateBar(float currentValue, float maxValue)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(SmoothCoroutine(currentValue, maxValue));
        }

        private IEnumerator SmoothCoroutine(float currentValue, float maxValue)
        {
            while (Mathf.Abs(_slider.value - currentValue / maxValue) > Epsilon)
            {
                _slider.value = Mathf.MoveTowards(
                    _slider.value,
                    currentValue / maxValue,
                    _speed * Time.deltaTime
                );

                yield return null;
            }
        }
    }
}