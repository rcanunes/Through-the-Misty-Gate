using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Equipment : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<Sprite> defaultImages;

    Transform equipSlot;
    EquipmentManager equipmentManager;

    private void Start()
    {
        equipSlot = transform.Find("EquipSlot");
        equipmentManager = EquipmentManager.instance;

        equipmentManager.modifyEquipment += UpdateEquipmentVisual;
        UpdateEquipmentVisual(null, null);

    }

    public void UpdateEquipmentVisual(Equipment nemItem, Equipment oldItem)
    {

        foreach (Transform child in transform)
        {
            if (child == equipSlot) continue;
            Destroy(child.gameObject);
        }

        int length = System.Enum.GetNames(typeof(TypeOfEquipment)).Length;
        for (int i = 0; i < length; i++)
        {
            Transform equipSlotTransform = Instantiate(equipSlot, transform);
            equipSlotTransform.gameObject.SetActive(true);

            if (equipmentManager.currentEquipment[i] != null)
            {
                equipSlotTransform.GetComponent<EquipmentSlot>().Setup(equipmentManager.currentEquipment[i]);
            }

            else
            {
                Color test = Color.black;
                test.a = 0.2f;

                equipSlotTransform.Find("ItemIcon").GetComponent<Image>().sprite = defaultImages[i];
                equipSlotTransform.Find("ItemIcon").GetComponent<Image>().color = test;
            }
        }
    }

}
