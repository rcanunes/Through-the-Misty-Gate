using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Spell
    {
        Fireball,
        Shield,
        LightSword,
        Boost
    }

    public Spell currentSpell = Spell.Fireball;

    public void ActivateSpell()
    {
        switch (currentSpell)
        {
            case Spell.Fireball:
                Debug.Log("Fireball");
                break;
            case Spell.Shield:
                Debug.Log("Shield");
                break;
            case Spell.LightSword:
                Debug.Log("LightSword");
                break;
            case Spell.Boost:
                Debug.Log("Boost");
                break;
            default:
                break;
        }
    }

    public void SetSpell(Spell spell)
    {
        currentSpell = spell;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ActivateSpell();
        }
    }

    public Spell GetCurrentSpell()
    {
        return currentSpell;
    }
}
