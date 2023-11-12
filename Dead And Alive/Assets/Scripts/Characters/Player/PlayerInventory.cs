using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    [SerializeField] private int inventorySize = 10;
    private InventoryItem[] inventoryItems;
    private InputActions actions;

    public float interactRange = 5;

    private void Awake() {
        inventoryItems = new InventoryItem[inventorySize];
        actions = new InputActions();

        // PrintInventory();
    }

    private void OnEnable() {
        actions.Enable();

        actions.Player.Interact.performed += context => Interact();
    }

    private void OnDisable() {
        actions.Player.Interact.performed -= context => Interact();

        actions.Disable();
    }

    private void Interact()
    {
        GrabbableItem closestItem = null;
        InteractableItem closestInteractable = null;
        float closestRange = interactRange;

        foreach (GrabbableItem i in FindObjectsOfType<GrabbableItem>())
        {
            float range = Vector3.Distance(transform.position, i.transform.position);

            if (range < closestRange)
            {
                closestItem = i;
                closestRange = range;
            }
        }

        foreach (InteractableItem i in FindObjectsOfType<InteractableItem>())
        {
            if (!i.interactable) continue;

            float range = Vector3.Distance(transform.position, i.transform.position);

            if (range < closestRange)
            {
                closestInteractable = i;
                closestRange = range;
            }
        }

        if (closestInteractable != null) 
        {
            closestInteractable.Interact();
            return;
        }

        if (closestItem == null) return;

        AddToInventory(closestItem);
    }

    public bool AddToInventory(InventoryItem item)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] == null)
            {
                inventoryItems[i] = item;
                return true;
            }
        }
        Debug.Log("Inventory is full");
        return false;
    }

    private void AddToInventory(GrabbableItem item)
    {
        bool cangrab = AddToInventory(item.GetItem());
        if (cangrab) item.Grabbed();
    }

    private void PrintInventory()
    {
        foreach (InventoryItem item in inventoryItems)
            Debug.Log(item.itemName);
    }
}