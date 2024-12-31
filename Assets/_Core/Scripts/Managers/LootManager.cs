using UnityEngine;
using UnityEngine.Pool;

public class LootManager : Singleton<LootManager>
{
    [SerializeField] private Lootable lootablePrefab;
    private IObjectPool<Lootable> lootPool;

    private void Init()
    {
            
    }
    
    private void Awake()
    {
        lootPool = new ObjectPool<Lootable>(
            CreateLootable,
            OnTakeFromPool,
            OnReturnedToPool,
            OnDestroyPoolObject,
            false,
            10,
            30
        );
    }

    private Lootable CreateLootable()
    {
        Lootable newLootable = Instantiate(lootablePrefab);
        newLootable.DisableCollider();
        newLootable.gameObject.SetActive(false);
        return newLootable;
    }

    private void OnTakeFromPool(Lootable lootable)
    {
        lootable.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(Lootable lootable)
    {
        lootable.DisableCollider();
        lootable.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Lootable lootable)
    {
        Destroy(lootable.gameObject);
    }

    public Lootable GetLootable()
    {
        Lootable lootable = lootPool.Get();
        return lootable;
    }

    public void ReleaseLootable(Lootable lootable)
    {
        lootPool.Release(lootable);
    }
}
