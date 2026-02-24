using UnityEngine;
using UnityEngine.Pool;

namespace Game.Scripts.Entities.Base
{
    public abstract class PoolBase<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T _potionPrefab;
        [SerializeField] private int _capacity;
        [SerializeField] private int _maxSize;
        
        private ObjectPool<T> _pool;
    
        protected virtual void Awake()
        {
            _pool = new ObjectPool<T>(
                createFunc: () => CreateObject(),
                actionOnGet: (obj) => OnGetObject(obj),
                actionOnRelease: (obj) => OnReleaseObject(obj),
                actionOnDestroy: (obj) => Destroy(obj),
                collectionCheck: true,
                defaultCapacity: _capacity,
                maxSize: _maxSize);
        }
    
        public T Get()
        {
            return _pool.Get();
        }

        public void Release(T entity)
        {
            _pool.Release(entity);
        }

        protected virtual T CreateObject()
        {
            return Instantiate(_potionPrefab);
        }

        protected virtual void OnGetObject(T entity)
        {
            entity.gameObject.SetActive(true);
        }
    
        protected virtual void OnReleaseObject(T entity)
        {
            entity.gameObject.SetActive(false);
        }
    }
}