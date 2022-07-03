using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SpellBookIcon : MonoBehaviour
{
    [SerializeField] SpellCaster spellCaster;
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
        spellCaster.modifySpell += SpellCaster_modifySpell; ;
    }

    private void SpellCaster_modifySpell(Spell spell)
    {
        StartCoroutine(Flicker());
    }



    IEnumerator Flicker()
    {
        image.color = new Color(1f, 1f, 0f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        image.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        image.color = new Color(1f, 1f, 0f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        image.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        image.color = new Color(1f, 1f, 0f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        image.color = Color.white;
    }
}
