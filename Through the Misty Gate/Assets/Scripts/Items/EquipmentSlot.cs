using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{

    [SerializeField] public Equipment item;
    public void Setup(Equipment _item)
    {
        item = _item;
        transform.Find("ItemIcon").GetComponent<Image>().sprite = item.image;
    }

    public void UnequipItem()
    {
        EquipmentManager.instance.Unequip((int)item.type);
    }


}
