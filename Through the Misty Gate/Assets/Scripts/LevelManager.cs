using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private bool toogleSpellBook;
    [SerializeField] CanvasGroup spellBookCanvasGroup;
    [SerializeField] RectTransform spellInfo;
    [SerializeField] Camera mainCamera;

    public float target = 225;


    private void Awake()
    {
        instance = this;
        toogleSpellBook = false;
        MakeSpellBookInvisible();
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
        if (ToogleKeysDown())
        {
            ToogleSpellBook();
        }

    }

    public void CheckSpellInfoSide()
    {
        if (spellInfo.parent.GetComponent<RectTransform>().anchoredPosition.x < 0)
        {
            spellInfo.GetComponent<SmallAnimation>().targetPos = target;
        }
        else if (spellInfo.parent.GetComponent<RectTransform>().anchoredPosition.x > 0)
        {
            spellInfo.GetComponent<SmallAnimation>().targetPos = -target;
        }

    }

    private bool ToogleKeysDown()
    {
        return Input.GetKeyDown(KeyCode.T);
    }

    private void ToogleSpellBook()
    {
        toogleSpellBook = !toogleSpellBook;
        if (toogleSpellBook)
        {
            MakeSpellBookVisible();
        }
        else
            MakeSpellBookInvisible();
    }

    public bool CanClick()
    {
        Debug.Log("IsOver? - " + isMouseOverUI().ToString());
        return !toogleSpellBook && !isMouseOverUI();
    }

    public bool IsSpellBookVisible()
    {
        return toogleSpellBook;
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
            Debug.Log("Gameonkect - " + ray.gameObject.name);
        }

        return raycastResults.Count > 0;
    }


}
