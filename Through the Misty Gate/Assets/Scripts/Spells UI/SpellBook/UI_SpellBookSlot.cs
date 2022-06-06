using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_SpellBookSlot : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 startAnchoredPosition;

    private SpellBookSystem spellBookSystem;
    public UI_ItemManager.HotKeyAbility hotKeyAbility;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public UI_ItemManager.HotKeyAbility GetSpell()
    {
        return hotKeyAbility;
    }


    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    }

    public void SetUp(SpellBookSystem spellBookSystem, UI_ItemManager.HotKeyAbility hotKeyAbility)
    {
        this.hotKeyAbility = hotKeyAbility;
        this.spellBookSystem = spellBookSystem;
    }


    private void Start()
    {
        startAnchoredPosition = rectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = startAnchoredPosition;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        spellBookSystem.InvokeOnSpellChange();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        transform.SetAsLastSibling();
    }
}
