using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private Sprite sprite;
    [TextArea]
    [SerializeField]
    private string itemDescription;
    private InventoryManager.Manager.InventoryManager inventoryManager;
    public InventoryManager.Manager.InventoryManager.ItemType itemType;
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager.Manager.InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription, itemType);
            if (leftOverItems <= 0)
                Destroy(gameObject);
            else quantity = leftOverItems;
        }
    }
    void Update()
    {

    }
}
