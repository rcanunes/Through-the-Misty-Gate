using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Transform itemSlot;
    private Transform itemSlotContainer;
    Inventory inventory;

    private void Start()
    {
        itemSlotContainer = transform.Find("ScrollView/Viewport/Content");
        itemSlot = itemSlotContainer.Find("ItemSlot");
        inventory = Inventory.instance;

        inventory.ModifyInventory += UpdateInventoryVisual;

        UpdateInventoryVisual();
    }


    private void UpdateInventoryVisual()
    {

        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlot) continue;
            Destroy(child.gameObject);
        }

        
        foreach (Item item in inventory.items)
        {  
            Transform itemSlotTransform = Instantiate(itemSlot, itemSlotContainer);
            itemSlotTransform.gameObject.SetActive(true);
            itemSlotTransform.GetComponent<ItemSlot>().Setup(item);

        }
    }

}
