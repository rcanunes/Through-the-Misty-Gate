using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    [SerializeField] private Item item;
    public void Setup(Item _item)
    {
        item = _item;
        transform.Find("ItemIcon").GetComponent<Image>().sprite = item.image;

    }

    public void UseItem()
    {
        item.Use();
    }


}
