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

    }

    private void ToogleInventory()
    {
        if (inventoryUI.activeSelf)
            inventoryUI.SetActive(false);
        else
            inventoryUI.SetActive(true);
    }

    private void ToogleSpellBook()
    {
        if (spellBookUI.activeSelf)
            spellBookUI.SetActive(false);
        else
            spellBookUI.SetActive(true);
    }

    private bool ToogleInventoryKeysDown()
    {
        return Input.GetKeyDown(KeyCode.I);
    }

    private bool ToogleSpellBookKeysDown()
    {
        return Input.GetKeyDown(KeyCode.T);
    }


    public bool CanClick()
    {
        return !spellBookUI.activeSelf && !isMouseOverUI();
    }

    public bool IsSpellBookVisible()
    {
        return spellBookUI.activeSelf;
    }

    public bool IsInventoryVisible()
    {
        return spellBookUI.activeSelf;
    }

    private bool isMouseOverUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        foreach (RaycastResult ray in raycastResults)
        {

            if (ray.gameObject.GetComponent<MouseUIClickThrough>() != null)
            {
                raycastResults.Remove(ray);
            }
        }

        return raycastResults.Count > 0;
    }


}
