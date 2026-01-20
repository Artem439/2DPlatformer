using UnityEngine;
using UnityEngine.Pool;

namespace Game.Scripts.Entities.Coin
{
    public class CoinsPool : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private int _capacity;
        [SerializeField] private int _maxSize;
        
        private ObjectPool<Coin> _cubesPool;
    
        private void Awake()
        {
            _cubesPool = new ObjectPool<Coin>(
                createFunc: () => CreateObject(),
                actionOnGet: (obj) => OnGetObject(obj),
                actionOnRelease: (obj) => OnReleaseObject(obj),
                actionOnDestroy: (obj) => Destroy(obj),
                collectionCheck: true,
                defaultCapacity: _capacity,
                maxSize: _maxSize);
        }
    
        public Coin Get()
        {
            return _cubesPool.Get();
        }

        public void Release(Coin coin)
        {
            _cubesPool.Release(coin);
        }

        private Coin CreateObject()
        {
            return Instantiate(_coinPrefab);
        }

        private void OnGetObject(Coin coin)
        {
            coin.gameObject.SetActive(true);
        }
    
        private void OnReleaseObject(Coin coin)
        {
            coin.gameObject.SetActive(false);
        }
    }
}