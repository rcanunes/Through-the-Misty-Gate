using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Equipment : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<EquipmentSlot> equipment;

    public void UpdateEquipmentVisual()
    {
        int length = System.Enum.GetNames(typeof(TypeOfEquipment)).Length;
        for (int i = 0; i < length; i++)
        {
            if (equipment[i].item != null)
            {
                
            }
        }
    }
}
