using UnityEngine;
namespace InventoryManager.Item

{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ItemSO")]
    public class ItemSO : ScriptableObject
    {
        public string itemName;
        public int quantity;
        public Sprite itemSprite;
        public string itemDescription;
        public InventoryManager.Manager.InventoryManager.ItemType itemType;

        public bool UseItem()
        {
            // Implementation for using the item
            // ...
            return true; // Return true if the item can be used, false otherwise
        }
    }
}