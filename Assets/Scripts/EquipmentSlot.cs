using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using InventoryManager;
using System;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
    // ITEM DATA
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public InventoryManager.Manager.InventoryManager.ItemType itemType;
    public Sprite emptySprite;

    // Item Slot

    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemImage;


    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager.Manager.InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager.Manager.InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, InventoryManager.Manager.InventoryManager.ItemType itemType)
    {
        if (isFull)
            return quantity;
        this.itemType = itemType;
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        this.itemDescription = itemDescription;
        this.quantity = 1;
        isFull = true;
        return 0;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            bool usable = inventoryManager.UseItem(itemName);
            if (usable)
            {
                this.quantity -= 1;
                quantityText.text = quantity.ToString();
                if (this.quantity <= 0)
                {
                    EmptySlot();
                }
            }
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
    }
    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;
    }
    public void OnRightClick()
    {

    }


}

