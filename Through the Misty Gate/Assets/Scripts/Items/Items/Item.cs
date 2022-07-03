using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite image;
    //public GameObject prefab; 
    
    public virtual void Use()
    {
        Debug.Log("Using" + itemName);
    }

}
