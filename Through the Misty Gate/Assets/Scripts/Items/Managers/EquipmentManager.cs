using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton    
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Equipment[] currentEquipment;
    Inventory inventory;

    public delegate void ModifyEquipment(Equipment newItem, Equipment oldItem);
    public event ModifyEquipment modifyEquipment;


    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(TypeOfEquipment)).Length;
        currentEquipment = new Equipment[numSlots];

        inventory = Inventory.instance;
    }

    public void Equip(Equipment item)
    {
        int index = (int)item.type;

        Equipment oldItem = null;

        if (currentEquipment[index] != null)
        {
            oldItem = currentEquipment[index];
            inventory.AddItem(oldItem);
        }
            
        currentEquipment[index] = item;

        modifyEquipment?.Invoke(item, oldItem);

    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
            currentEquipment[slotIndex] = null;


            modifyEquipment?.Invoke(null, oldItem);

        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }

    }

}
