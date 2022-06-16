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

    public void CheckSpellInfo()
    {
        Debug.Log(spellInfo.parent.GetComponent<RectTransform>().anchoredPosition);
        if (spellInfo.parent.GetComponent<RectTransform>().anchoredPosition.x < 0 && spellInfo.anchoredPosition.x < 0)
        {
            spellInfo.anchoredPosition = new Vector2( - spellInfo.anchoredPosition.x, spellInfo.anchoredPosition.y);
        }
        else if (spellInfo.parent.GetComponent<RectTransform>().anchoredPosition.x > 0 && spellInfo.anchoredPosition.x > 0)
        {
            spellInfo.anchoredPosition = new Vector2(-spellInfo.anchoredPosition.x, spellInfo.anchoredPosition.y);
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

    private bool isMouseOverUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        foreach (RaycastResult ray in raycastResults)
        {
            Debug.Log("rayname "  + ray.gameObject.name);

            if (ray.gameObject.GetComponent<MouseUIClickThrough>() != null)
            {
                raycastResults.Remove(ray);
            }

        }

        return raycastResults.Count > 0;
    }


}
