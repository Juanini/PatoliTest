using DG.Tweening;
using Obvious.Soap;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [SerializeField] private IntVariable lootToIncrease;
    [SerializeField] private BoxCollider2D boxCollider2D;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(Constants.TAG_PLAYER)) return;
        Loot();
    }

    public void EnableCollider() => boxCollider2D.enabled = true;
    public void DisableCollider() => boxCollider2D.enabled = false;

    private void Loot()
    {
        lootToIncrease.Add(1);
        LootManager.Ins.ReleaseLootable(this);
    }

    public async void DoAnim(Vector2 coinPosition)
    {
        await transform.DOJump(coinPosition, 2, 1, 0.5f).AsyncWaitForCompletion();
        EnableCollider();
    }
}
