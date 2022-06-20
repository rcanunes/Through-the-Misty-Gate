using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
            instance = null;
        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();


    public delegate void EventHandler();
    public event EventHandler ModifyInventory;

    //public int slots = 20;

    public bool AddItem(Item item)
    {
        //if (items.Count == slots)
        //{
        //    Debug.Log("ToMuchItems");
        //    return false;
        //}
        items.Add(item);
        ModifyInventory?.Invoke();
        return true;
    }

    public void RemoveItem(Item item)
    {

        items.Remove(item);
        ModifyInventory?.Invoke();
    }


}
