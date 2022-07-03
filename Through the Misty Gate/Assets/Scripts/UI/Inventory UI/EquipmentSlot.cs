using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerExitHandler
{

    [SerializeField] public Equipment item;
    [SerializeField] RectTransform itemInfo;

    public void Setup(Equipment _item)
    {
        item = _item;
        transform.Find("ItemIcon").GetComponent<Image>().sprite = item.image;
    }

    public void UnequipItem()
    {
        if (item == null)
        {
            return;
        }
        EquipmentManager.instance.Unequip((int)item.type);
    }

    public void ShowInfo()
    {
        SetUpItemInfo();
    }


    private void SetUpItemInfo()
    {
        if (this.item == null)
            return;
        itemInfo.Find("Item Name").GetComponent<TextMeshProUGUI>().text = this.item.itemName;
        itemInfo.Find("Type").GetComponent<TextMeshProUGUI>().text = "Type: " + this.item.type.ToString();

        string extraDescription = "";

        if (item.modifiers.healthModifer != 0)
        {
            extraDescription += IncreasesDecresases(item.modifiers.healthModifer);
            extraDescription += " the health of the wearer by " + item.modifiers.healthModifer + "%\n";
        }
        if (item.modifiers.armourModifier != 0)
        {
            extraDescription += IncreasesDecresases(item.modifiers.armourModifier);
            extraDescription += " the damage taken by " + item.modifiers.armourModifier + "%\n";
        }
        if (item.modifiers.jumpModifier != 0)
        {
            extraDescription += IncreasesDecresases(item.modifiers.jumpModifier);
            extraDescription += " the jump height by " + item.modifiers.jumpModifier + "%\n";
        }
        if (item.modifiers.speedModifier != 0)
        {
            extraDescription += IncreasesDecresases(item.modifiers.speedModifier);
            extraDescription += " the movement speed by " + item.modifiers.speedModifier + "%\n";
        }
        if (item.modifiers.baseDamageModifier != 0)
        {
            extraDescription += IncreasesDecresases(item.modifiers.baseDamageModifier);
            extraDescription += " the damage dealt by " + item.modifiers.baseDamageModifier + "%\n";
        }
        if (item.modifiers.fireDamageModifer != 0)
        {
            extraDescription += IncreasesDecresases(item.modifiers.fireDamageModifer);
            extraDescription += " the fire damage dealt by " + item.modifiers.fireDamageModifer + "%\n";
        }
        if (item.modifiers.iceDamageModifier != 0)
        {
            extraDescription += IncreasesDecresases(item.modifiers.iceDamageModifier);
            extraDescription += " the ice damage dealt by " + item.modifiers.iceDamageModifier + "%\n";
        }

        itemInfo.Find("Info").GetComponent<TextMeshProUGUI>().text = "Info: " + this.item.description + "\n" + extraDescription;

        if (!itemInfo.gameObject.activeSelf)
            itemInfo.gameObject.SetActive(true);
        else { 
        }

    }

    private string IncreasesDecresases(float modifier)
    {
        if (modifier > 0)
        {
            return "Increases";
        }

        return "Decreases";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //if (itemInfo.gameObject.activeSelf)
        //    itemInfo.GetComponent<SmallAnimation>().OnCLose();
    }

}
