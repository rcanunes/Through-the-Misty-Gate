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
        EquipmentManager.instance.Unequip((int)item.type);
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
        itemInfo.Find("Type").GetComponent<TextMeshProUGUI>().text = "Type: " + item.type.ToString();
        itemInfo.Find("Info").GetComponent<TextMeshProUGUI>().text = "Info: " + item.description;

        if (!itemInfo.gameObject.activeSelf)
            itemInfo.gameObject.SetActive(true);
        else { 
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemInfo.gameObject.activeSelf)
            itemInfo.GetComponent<SmallAnimation>().OnCLose();
    }

}
