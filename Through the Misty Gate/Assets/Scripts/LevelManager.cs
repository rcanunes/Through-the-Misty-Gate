using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public bool toogleSpellBook;

    [SerializeField] CanvasGroup spellBookCanvasGroup;
    //[SerializeField] RectTransform spellInfo;
    [SerializeField] Camera mainCamera;

    //public float target = 225;

    public bool toogleInventory;
    [SerializeField] GameObject inventoryUI;


    private void Awake()
    {
        instance = this;
        toogleSpellBook = false;
        toogleInventory = false;
        MakeSpellBookInvisible();
        inventoryUI.SetActive(toogleInventory);
    }

    public void MakeSpellBookVisible()
    {
        spellBookCanvasGroup.interactable = true;
        spellBookCanvasGroup.alpha = 1;
        spellBookCanvasGroup.blocksRaycasts = true;

    }

    public void MakeSpellBookInvisible()
    {
        spellBookCanvasGroup.interactable = false;
        spellBookCanvasGroup.alpha = 0;
        spellBookCanvasGroup.blocksRaycasts = false;

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
        toogleInventory = !toogleInventory;
        if (toogleInventory &&  toogleSpellBook)
            ToogleSpellBook();
        inventoryUI.SetActive(toogleInventory);
    }

    private bool ToogleInventoryKeysDown()
    {
        return Input.GetKeyDown(KeyCode.I);
    }

    //public void CheckSpellInfoSide()
    //{
    //    if (spellInfo.parent.GetComponent<RectTransform>().anchoredPosition.x < 0)
    //    {
    //        spellInfo.GetComponent<SmallAnimation>().targetPos = target;
    //    }
    //    else if (spellInfo.parent.GetComponent<RectTransform>().anchoredPosition.x > 0)
    //    {
    //        spellInfo.GetComponent<SmallAnimation>().targetPos = -target;
    //    }

    //}

    private bool ToogleSpellBookKeysDown()
    {
        return Input.GetKeyDown(KeyCode.T);
    }

    private void ToogleSpellBook()
    {
        toogleSpellBook = !toogleSpellBook;


        if (toogleSpellBook)
        {
            MakeSpellBookVisible();
            if (toogleInventory)
                ToogleInventory();
        }
        else
            MakeSpellBookInvisible();


    }

    public bool CanClick()
    {
        return !toogleSpellBook && !isMouseOverUI();
    }

    public bool IsSpellBookVisible()
    {
        return toogleSpellBook;
    }

    public bool IsInventoryVisible()
    {
        return toogleInventory;
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
