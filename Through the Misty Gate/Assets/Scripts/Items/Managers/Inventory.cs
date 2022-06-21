using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] RectTransform lorePage;


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
        if (item is LoreItem)
        {
            ShowLore((LoreItem)item);
        }
    

        return true;
    }

    public void RemoveItem(Item item)
    {

        items.Remove(item);
        ModifyInventory?.Invoke();
    }

    public void ShowLore(LoreItem item)
    {
        lorePage.gameObject.SetActive(true);
        lorePage.Find("Lore").GetComponent<TextMeshProUGUI>().text = item.description;
    }


}
