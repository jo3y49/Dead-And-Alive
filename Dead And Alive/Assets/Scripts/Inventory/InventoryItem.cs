using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "CreateItemData")]
public class InventoryItem : ScriptableObject {
    public string itemName = "";
    public Sprite sprite;
}