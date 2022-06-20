
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_SpellBookSlot : MonoBehaviour, IPointerDownHandler
    {
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 startAnchoredPosition;

    private SpellBookSystem spellBookSystem;
    private HotKeySystem hotKeySystem;
    public UI_ItemManager.HotKeyAbility hotKeyAbility;
    [SerializeField] Transform spellInfo;
    private GameObject temp;

    private Transform spellSlotContainer;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

        public UI_ItemManager.HotKeyAbility GetSpell() {
            return hotKeyAbility;
        }


    //public void OnDrag(PointerEventData eventData)
    //{
    //    rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    //}

    public void SetUp(SpellBookSystem spellBookSystem, UI_ItemManager.HotKeyAbility hotKeyAbility, HotKeySystem hotKeySystem, Transform spellSlotContainer)
    {
        this.hotKeySystem = hotKeySystem;
        this.hotKeyAbility = hotKeyAbility;
        this.spellBookSystem = spellBookSystem;
        this.spellSlotContainer = spellSlotContainer;
    }


        private void Start() {
            startAnchoredPosition = rectTransform.anchoredPosition;
        }

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    rectTransform.anchoredPosition = startAnchoredPosition;
    //    canvasGroup.alpha = 1;
    //    canvasGroup.blocksRaycasts = true;
    //    spellBookSystem.InvokeOnSpellChange();
    //    Destroy(temp);
    //}

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    canvasGroup.alpha = .6f;
    //    canvasGroup.blocksRaycasts = false;
    //    transform.SetAsLastSibling();

    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            hotKeySystem.AddSpell(hotKeyAbility);
            spellBookSystem.InvokeOnSpellChange();
        }

        else if(eventData.button == PointerEventData.InputButton.Left)
        {
            SetUpSpellInfo();
        }
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
        // LevelManager.instance.CheckSpellInfo();
        //SetUpSpellInfo();
    //}

        private void SetUpSpellInfo() {

            spellInfo.Find("Spell Name").GetComponent<TextMeshProUGUI>().text = hotKeyAbility.spell.name;
            spellInfo.Find("Cooldown").GetComponent<TextMeshProUGUI>().text =
                "Cooldown: " + hotKeyAbility.spell.cooldown.ToString();
            spellInfo.Find("Description").GetComponent<TextMeshProUGUI>().text =
                "Info: " + hotKeyAbility.spell.spellDescription;

        spellInfo.gameObject.SetActive(true);

    }
}
