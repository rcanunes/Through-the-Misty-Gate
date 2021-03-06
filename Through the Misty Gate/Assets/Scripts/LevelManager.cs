using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] Camera mainCamera;

    public GameObject inventoryUI;
    public GameObject pageLoreUI;
    public GameObject spellBookUI;


    private void Awake()
    {
        instance = this;
        inventoryUI.SetActive(false);
        pageLoreUI.SetActive(false);
        spellBookUI.SetActive(false);
    }



    private void Update()
    {
        if (ToogleSpellBookKeysDown())
        {
            ToogleSpellBook();
        }

        if (ToogleInventoryKeysDown())
        {
            ToogleInventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TooglAllOff();
        }

    }

    private void TooglAllOff()
    {
        inventoryUI.SetActive(false);
        pageLoreUI.SetActive(false);
        spellBookUI.SetActive(false);
    }

    private void ToogleInventory()
    {
        if (inventoryUI.activeSelf)
            inventoryUI.SetActive(false);
        else
        {
            spellBookUI.SetActive(false);
            pageLoreUI.SetActive(false);
            inventoryUI.SetActive(true);
        }
    }

    private void ToogleSpellBook()
    {
        if (spellBookUI.activeSelf)
            spellBookUI.SetActive(false);
        else
        {
            inventoryUI.SetActive(false);
            pageLoreUI.SetActive(false);
            spellBookUI.SetActive(true);

        }
    }

    internal void ActivateLorePage()
    {
        pageLoreUI.SetActive(true);
        spellBookUI.SetActive(false);
        inventoryUI.SetActive(false);
    }

    private bool ToogleInventoryKeysDown()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private bool ToogleSpellBookKeysDown()
    {
        return Input.GetKeyDown(KeyCode.T);
    }


  
    public bool CantCast()
    {
        return spellBookUI.activeSelf || inventoryUI.activeSelf || pageLoreUI.activeSelf;
    }

    public bool IsSpellBookVisible()
    {
        return spellBookUI.activeSelf;
    }

    public bool IsInventoryVisible()
    {
        return spellBookUI.activeSelf;
    }

    public List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }

    public bool IsPointerOverUIElement(string layer)
    {

        int uiLayer = LayerMask.NameToLayer(layer);

        if (uiLayer == -1)
        {
            Debug.Log("Nope Layer");
            return false;
        }

        List<RaycastResult> eventSystemRaysastResults = GetEventSystemRaycastResults();

        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == uiLayer)
                return true;
        }
        return false;
    }



}
