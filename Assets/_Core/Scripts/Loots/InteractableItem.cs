using System;
using Obvious.Soap;
using UnityEngine;

public abstract class InteractableItem : MonoBehaviour
{
    [SerializeField] private InteractableItemVariable activeInteractableItemVar;
    [SerializeField] private Transform uiSpawnPos;

    private bool isActive = true;
    public bool IsActive => isActive;

    public abstract void OnInteractT();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(Constants.TAG_PLAYER)) { return; }
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
        return uiSpawnPos.transform.position;
    }
}
