using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    [SerializeField] private int inventorySize = 10;
    private InventoryItem[] inventoryItems;

    private void Awake() {
        inventoryItems = new InventoryItem[inventorySize];

        // PrintInventory();
    }

    public void AddToInventory(InventoryItem item)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] == null)
            {
                inventoryItems[i] = item;
                return;
            }
        }
        Debug.Log("Inventory is full");
    }

    private void PrintInventory()
    {
        foreach (InventoryItem item in inventoryItems)
            Debug.Log(item.itemName);
    }
}