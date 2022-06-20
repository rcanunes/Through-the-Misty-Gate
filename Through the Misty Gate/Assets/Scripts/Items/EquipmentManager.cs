using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton    
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;
    Inventory inventory;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(TypeOfEquipment)).Length;
        currentEquipment = new Equipment[numSlots];

        inventory = Inventory.instance;
    }

    public void Equip(Equipment item)
    {
        int index = (int)item.type;

        Unequip(index);

        currentEquipment[index] = item;

    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
            currentEquipment[slotIndex] = null;
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
