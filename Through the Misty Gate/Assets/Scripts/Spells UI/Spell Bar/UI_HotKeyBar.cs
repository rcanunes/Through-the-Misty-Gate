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
        HotKeyBarUpdateVisual();
        hotKeySystem.OnAbilityListChange += HotKeySystem_OnAbilityListChange;
    }

    private void HotKeySystem_OnAbilityListChange(object sender, EventArgs e)
    {
        HotKeyBarUpdateVisual();
    }

    private void HotKeyBarUpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == spellSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        List<UI_ItemManager.HotKeyAbility> hotKeyAbilitiesList = hotKeySystem.GetSpells();
        for (int i = 0; i < hotKeySystem.MaxSpells ; i++)
        {

            if (i < hotKeyAbilitiesList.Count) {
                UI_ItemManager.HotKeyAbility hotKeyAbility = hotKeyAbilitiesList[i];
                Transform spellSlotTransform = Instantiate(spellSlotTemplate, transform);
                spellSlotTransform.gameObject.SetActive(true);
                RectTransform spellSlotRectTransforms = spellSlotTransform.GetComponent<RectTransform>();
                spellSlotRectTransforms.anchoredPosition = new Vector2(60f * i, 0f);
                spellSlotTransform.Find("SpellIcon").GetComponent<Image>().sprite = hotKeyAbility.GetSprite();
                spellSlotTransform.Find("Number").Find("Number").GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();

                if (hotKeySystem.GetCurrentSpell() == hotKeyAbility.spellType)
                {
                    Debug.Log(i.ToString() + " " + hotKeyAbility.spellType.ToString());
                    spellSlotTransform.Find("Border").GetComponent<Image>().color = Color.red;
                }

                spellSlotTransform.GetComponent<UI_HotKeyBarSpellSlot>().SetUp(i, hotKeySystem, hotKeyAbility);
            }

            else
            {
                Transform spellSlotTransform = Instantiate(spellSlotTemplate, transform);
                spellSlotTransform.gameObject.SetActive(true);
                RectTransform spellSlotRectTransforms = spellSlotTransform.GetComponent<RectTransform>();
                spellSlotRectTransforms.anchoredPosition = new Vector2(60f * i, 0f);
                spellSlotTransform.Find("Number").Find("Number").GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();

                Color test = Color.white;
                test.a = 0;

                spellSlotTransform.Find("SpellIcon").GetComponent<Image>().color = test ;
                spellSlotTransform.GetComponent<UI_HotKeyBarSpellSlot>().SetUp(i, hotKeySystem, null);

            }

        }
    }


}
