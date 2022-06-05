using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_HotKeyBar : MonoBehaviour
{
    private Transform spellSlotTemplate;
    private HotKeySystem hotKeySystem;
    private void Awake()
    {
        spellSlotTemplate = transform.Find("spellSlotTemplate");
        spellSlotTemplate.gameObject.SetActive(false);
    }

    public void SetHotKeySystem(HotKeySystem hotKeySystem)
    {
        this.hotKeySystem = hotKeySystem;
        UpdateVisual();
        hotKeySystem.OnAbilityListChange += HotKeySystem_OnAbilityListChange;
    }

    private void HotKeySystem_OnAbilityListChange(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == spellSlotTemplate) continue;
            Destroy(child.gameObject);
        }


        List<HotKeySystem.HotKeyAbility> hotKeyAbilitiesList = hotKeySystem.GetAbilities();
        for(int i = 0; i < hotKeyAbilitiesList.Count; i++)
        {
            HotKeySystem.HotKeyAbility hotKeyAbility = hotKeyAbilitiesList[i];
            Transform spellSlotTransform = Instantiate(spellSlotTemplate, transform);
            spellSlotTransform.gameObject.SetActive(true);
            RectTransform spellSlotRectTransforms = spellSlotTransform.GetComponent<RectTransform>();
            spellSlotRectTransforms.anchoredPosition = new Vector2(60f * i, 0f);
            spellSlotTransform.Find("SpellIcon").GetComponent<Image>().sprite = hotKeyAbility.GetSprite();
            spellSlotTransform.Find("Number").Find("Number").GetComponent<TextMeshProUGUI>().text = (i+1).ToString();

            if (hotKeySystem.GetCurrentSpell() == hotKeyAbility.spellType)
                spellSlotTransform.Find("Border").GetComponent<Image>().color = Color.red;


            spellSlotTransform.GetComponent<UI_HotKeyBarSpellSlot>().SetUp(i, hotKeySystem, hotKeyAbility);
        }
    }
}
