using UnityEngine;
using UnityEngine.Pool;

namespace Game.Scripts.Entities.Coin
{
    [RequireComponent(typeof(CoinSpawner))]
    public class CoinsPool : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;

        private ObjectPool<Coin> _coinsPool;
        
        private CoinSpawner _coinSpawner;
    
        private void Awake()
        {
            _coinSpawner = GetComponent<CoinSpawner>();
            
            _coinsPool = new ObjectPool<Coin>(
                createFunc: () => CreateObject(),
                actionOnGet: (obj) => OnGetObject(obj),
                actionOnRelease: (obj) => OnReleaseObject(obj),
                actionOnDestroy: (obj) => Destroy(obj),
                collectionCheck: true,
                defaultCapacity: _coinSpawner.CountElements,
                maxSize: _coinSpawner.CountElements);
        }
    
        public Coin Get()
        {
            return _coinsPool.Get();
        }

        public void Release(Coin coin)
        {
            _coinsPool.Release(coin);
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