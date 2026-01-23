using UnityEngine;
using UnityEngine.Pool;

namespace Game.Scripts.Entities.HealPotion
{
    public class PotionsPool : MonoBehaviour
    {
        [SerializeField] private HealPotion _potionPrefab;
        [SerializeField] private int _capacity;
        [SerializeField] private int _maxSize;
        
        private ObjectPool<HealPotion> _potionsPool;
    
        private void Awake()
        {
            _potionsPool = new ObjectPool<HealPotion>(
                createFunc: () => CreateObject(),
                actionOnGet: (obj) => OnGetObject(obj),
                actionOnRelease: (obj) => OnReleaseObject(obj),
                actionOnDestroy: (obj) => Destroy(obj),
                collectionCheck: true,
                defaultCapacity: _capacity,
                maxSize: _maxSize);
        }
    
        public HealPotion Get()
        {
            return _potionsPool.Get();
        }

        public void Release(HealPotion potion)
        {
            _potionsPool.Release(potion);
        }

        private HealPotion CreateObject()
        {
            return Instantiate(_potionPrefab);
        }

        private void OnGetObject(HealPotion potion)
        {
            potion.gameObject.SetActive(true);
        }
    
        private void OnReleaseObject(HealPotion potion)
        {
            potion.gameObject.SetActive(false);
        }
    }
}