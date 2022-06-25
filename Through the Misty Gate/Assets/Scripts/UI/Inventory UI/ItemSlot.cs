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

        if(item is Equipment)
        {
            itemInfo.Find("Type").GetComponent<TextMeshProUGUI>().text = "Type: " + ((Equipment)item).type.ToString();
        }
        else
        {
            itemInfo.Find("Type").GetComponent<TextMeshProUGUI>().text = "";
        }

        if(item is LoreItem)
            itemInfo.Find("Info").GetComponent<TextMeshProUGUI>().text = "";
        else
            itemInfo.Find("Info").GetComponent<TextMeshProUGUI>().text = "Info: " + item.description;

        itemInfo.gameObject.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(itemInfo.gameObject.activeSelf)
            itemInfo.GetComponent<SmallAnimation>().OnCLose();
    }

}
