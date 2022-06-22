using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public Spell currentSpell;
    public List<Spell> knownSpells;

    public List<SpellCoolDown> coolDowns;
    public List<Spell> allSpells;

    CastingStatus castingStatus;
    public float castingTime;

    [SerializeField]
    UI_SpellCharging spellCharging;

    enum CastingStatus
    {
        Idle,
        Casting
    }

    private void Awake()
    {
        castingStatus = CastingStatus.Idle;
        castingTime = 0;
    }

    internal void RemoveCoolDown(SpellCoolDown spellCoolDown)
    {
        coolDowns.Remove(spellCoolDown);
    }

    public void AddToKnowSpells(Spell newSpell)
    {

    }

    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.Mouse0))
            StopCasting();

        switch (castingStatus)
        {
            case CastingStatus.Idle:

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    StartCasting();
                }

                break;

            case CastingStatus.Casting:

                if (castingTime >= currentSpell.chargeTime)
                {
                    CastSpell();
                    break;
                }

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    Casting();
                }
                break;

            default:
                Debug.Log("Wtf");
                break;
        }
    }

    private void StartCasting()
    {
        if (IsOnCoolDown(currentSpell))
        {
            return;
        }

        if (currentSpell == null)
            return;

        castingStatus = CastingStatus.Casting;
        spellCharging.gameObject.SetActive(true);
        spellCharging.SetCharger(currentSpell.chargeTime);
    }

    private bool IsOnCoolDown(Spell currentSpell)
    {
        foreach (SpellCoolDown coolDown in coolDowns)
        {
            if (coolDown.spell.name == currentSpell.name)
            {
                return true;
            }
        }

        return false;
    }

    private void StopCasting()
    {
        castingTime = 0;
        castingStatus = CastingStatus.Idle;
        spellCharging.gameObject.SetActive(false);
    }

    private void CastSpell()
    {
        StopCasting();
        SpellCoolDown temp = gameObject.AddComponent<SpellCoolDown>();
        temp.Initialize(this, currentSpell);
        coolDowns.Add(temp);
        currentSpell.Cast();
    }

    private void Casting()
    {
        castingTime += Time.deltaTime;
        spellCharging.UpdateCharger(castingTime);
    }

    public List<Spell> GetKnownSpells()
    {
        return knownSpells;
    }

    public void SetCurrentSpell(Spell spell)
    {
        currentSpell = spell;
    }
}
