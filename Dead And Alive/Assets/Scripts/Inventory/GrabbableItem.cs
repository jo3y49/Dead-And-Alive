using UnityEngine;

public class GrabbableItem : MonoBehaviour {
    [SerializeField] private InventoryItem inventoryItem;

    public InventoryItem GetItem()
    {
        return inventoryItem;
    }

    public void Grabbed()
    {
        Destroy(gameObject);
    }
}