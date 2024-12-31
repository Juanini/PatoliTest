using System;
using Cysharp.Threading.Tasks.Triggers;
using Obvious.Soap;
using TMPro;
using UnityEngine;

public class InteractableItemUI : MonoBehaviour
{
    public InteractableItemVariable activeInteractableItemVar;
    public GameObject visualIndicator;
    public TextMeshProUGUI visualIndicatorText;

    private bool isActive;

    private void Awake()
    {
        activeInteractableItemVar.OnValueChanged += OnInteractableItemChanged;
    }

    private void OnInteractableItemChanged(InteractableItem interactableItem)
    {
        isActive = interactableItem != null;
        
        if (isActive)
        {
            visualIndicator.transform.position = interactableItem.GetUISpawnPos();
            visualIndicator.SetActive(true);
        }
        else
        {
            visualIndicator.SetActive(false);
        }
    }

    void Update()
    {
        if (!isActive) { return; }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            activeInteractableItemVar.Value.OnInteractT();
        }
    }

    private void OnDestroy()
    {
        activeInteractableItemVar.OnValueChanged -= OnInteractableItemChanged;
    }
}
