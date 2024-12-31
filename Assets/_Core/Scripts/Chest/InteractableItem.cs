using System;
using Obvious.Soap;
using UnityEngine;

public abstract class InteractableItem : MonoBehaviour
{
    [SerializeField] private InteractableItemVariable activeInteractableItemVar;
    [SerializeField] private PositionHolder uiSpawnPos;

    private bool isActive = true;
    public bool IsActive => isActive;

    public abstract void OnInteractT();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive) { return; }
        activeInteractableItemVar.Value = this;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        activeInteractableItemVar.Value = null;   
    }
    
    protected void SetActive()
    {
        isActive = true;
    }
    
    protected void SetInactive()
    {
        isActive = false;
        activeInteractableItemVar.Value = null;
    }

    public Vector3 GetUISpawnPos()
    {
        return uiSpawnPos.localPositions[0];
    }
}
