using UnityEngine;

public class Chest : InteractableItem
{
    [SerializeField] private int coinsToGive;

    public override void OnInteractT()
    {
        if (!IsActive) { return; }
        GiveCoins();
    }
    
    private void GiveCoins()
    {
        SetInactive();
        Debug.Log("Give Coins");   
    }

}
