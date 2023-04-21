using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryManager.Item;

namespace InventoryManager.Manager
{
    public class InventoryManager : MonoBehaviour
    {
        public GameObject InventoryMenu;
        public ItemSlot[] itemSlot;
        public ItemSO[] itemSOs;
        public EquipmentSlot[] equipmentSlot;
        public ItemType itemType;
        void Start()
        {

        }


        void Update()
        {
            if (Input.GetButtonDown("InventoryMenu"))
            {
                Inventory();
            }
        }

        void Inventory()
        {
            if (InventoryMenu.activeSelf)
            {
                Time.timeScale = 1;
                InventoryMenu.SetActive(false);


            }
            else
            {
                Time.timeScale = 0;
                InventoryMenu.SetActive(true);

            }
        }
        public bool UseItem(string itemName)
        {
            for (int i = 0; i < itemSOs.Length; i++)
                if (itemSOs[i].itemName == itemName)
                {
                    bool usable = itemSOs[i].UseItem();
                    return usable;
                }
            return false;
        }
        public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)
        {
            if (itemType == ItemType.consumable || itemType == ItemType.crafting || itemType == ItemType.collectible)
            {
                for (int i = 0; i < itemSlot.Length; i++)
                {
                    if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
                    {
                        int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);
                        if (leftOverItems > 0)
                        {
                            leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType);
                            return leftOverItems;
                        }
                    }

                }
            }
            else
            {
                for (int i = 0; i < equipmentSlot.Length; i++)
                {
                    if (equipmentSlot[i].isFull == false && equipmentSlot[i].itemType == itemType || equipmentSlot[i].quantity == 0)
                    {
                        int leftOverItems = equipmentSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);
                        if (leftOverItems > 0)
                        {
                            leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType);
                            return leftOverItems;
                        }
                    }

                }

            }
            return quantity;
        }
        public void DeselectAllSlots()
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                itemSlot[i].selectedShader.SetActive(false);
                itemSlot[i].thisItemSelected = false;
            }
        }
        public enum ItemType
        {
            consumable,
            crafting,
            collectible,
            head,
            body,
            legs,
            feet,
            weapon,
            mainHand,
            offHand,
        };















    }
}