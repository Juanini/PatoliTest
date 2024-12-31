using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Chest : InteractableItem
{
    [SerializeField] private int coinsToGive;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    [SerializeField] private Color normalColor;
    [SerializeField] private Color inactiveColor;

    private List<Vector2> coinPositions;
    
    public override void OnInteractT()
    {
        if (!IsActive) { return; }
        GiveCoins();
    }
    
    private void GiveCoins()
    {
        SetInactive();

        CreateCoinsPositions();
        
        for (int i = 0; i < coinsToGive; i++)
        {
            var lootable = LootManager.Ins.GetLootable();
            lootable.transform.position = transform.position;
            lootable.DoAnim(coinPositions[i]);
        }
        
        spriteRenderer.color = inactiveColor;
    }
    
    // * =====================================================================================================================================
    // * 
    
    private void CreateCoinsPositions()
    {
        coinPositions = new List<Vector2>();
        int maxAttempts = 50;
        float minDistance = 0.5f;
        float minRadius = 1f;
        float maxRadius = 2f;
    
        for (int i = 0; i < coinsToGive; i++)
        {
            bool validPositionFound = false;
        
            for (int attempt = 0; attempt < maxAttempts && !validPositionFound; attempt++)
            {
                float angle = Random.Range(0f, 360f);
                float radius = Random.Range(minRadius, maxRadius);
                Vector2 offset = new Vector2(
                    Mathf.Cos(angle * Mathf.Deg2Rad),
                    Mathf.Sin(angle * Mathf.Deg2Rad)
                ) * radius;
                Vector2 candidatePosition = (Vector2)transform.position + offset;
            
                bool isOverlapping = false;
                foreach (Vector2 existingPos in coinPositions)
                {
                    if (Vector2.Distance(candidatePosition, existingPos) < minDistance)
                    {
                        isOverlapping = true;
                        break;
                    }
                }
            
                if (!isOverlapping)
                {
                    coinPositions.Add(candidatePosition);
                    validPositionFound = true;
                }
            }
        }
    }
}
