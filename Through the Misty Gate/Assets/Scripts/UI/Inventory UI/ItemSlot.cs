using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerExitHandler
{

    [SerializeField] private Item item;
    [SerializeField] RectTransform itemInfo;
    public void Setup(Item _item)
    {
        item = _item;
        transform.Find("ItemIcon").GetComponent<Image>().sprite = item.image;

        if (EquipmentManager.instance.ContainsEquipment(item))
        {
            Debug.Log("Testing2");

            Color test = Color.white;
            test.a = 0.2f;
            transform.Find("ItemIcon").GetComponent<Image>().color = test;
        }

    }

    public void UseItem()
    {
        item.Use();
    }

    public void ShowInfo()
    {
        SetUpItemInfo();
    }

    private void SetUpItemInfo()
    {

        if (item == null)
            return;

        itemInfo.Find("Item Name").GetComponent<TextMeshProUGUI>().text = item.itemName;

        string extraDescription = "";

        if (item is Equipment)
        {
            itemInfo.Find("Type").GetComponent<TextMeshProUGUI>().text = "Type: " + ((Equipment)item).type.ToString();
            Equipment equip = (Equipment)item;

            if (equip.modifiers.healthModifer != 0)
            {
                extraDescription += "It modifies the health of the wearer by " + equip.modifiers.healthModifer + "%\n";
            }
            if (equip.modifiers.armourModifier != 0)
            {
                extraDescription += "It modifies the damage taken by " + equip.modifiers.armourModifier + "%\n";
            }
            if (equip.modifiers.jumpModifier != 0)
            {
                extraDescription += "It modifies the jump height by " + equip.modifiers.jumpModifier + "%\n";
            }
            if (equip.modifiers.speedModifier != 0)
            {
                extraDescription += "It modifies the moement speed by " + equip.modifiers.speedModifier + "%\n";
            }
            if (equip.modifiers.baseDamageModifier != 0)
            {
                extraDescription += "It modifies the damage dealt by " + equip.modifiers.baseDamageModifier + "%\n";
            }
            if (equip.modifiers.fireDamageModifer != 0)
            {
                extraDescription += "It modifies the fire damage dealt by " + equip.modifiers.fireDamageModifer + "%\n";
            }
            if (equip.modifiers.iceDamageModifier != 0)
            {
                extraDescription += "It modifies the ice damage dealt by " + equip.modifiers.iceDamageModifier + "%\n";
            }

        }
        else
        {
            itemInfo.Find("Type").GetComponent<TextMeshProUGUI>().text = "";
        }


        //Get Descriptors:
       


        if(item is LoreItem)
            itemInfo.Find("Info").GetComponent<TextMeshProUGUI>().text = "";
        else
            itemInfo.Find("Info").GetComponent<TextMeshProUGUI>().text = "Info: " + item.description + "\n" + extraDescription;



        itemInfo.gameObject.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //if(itemInfo.gameObject.activeSelf)
        //    itemInfo.GetComponent<SmallAnimation>().OnCLose();
    }

}
