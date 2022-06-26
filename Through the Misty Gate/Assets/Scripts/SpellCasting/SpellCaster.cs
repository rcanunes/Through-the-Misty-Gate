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

    public CastingStatus castingStatus;
    public float castingTime;

    [SerializeField]
    UI_SpellCharging spellCharging;

    public delegate void ModifyKnownSpells(Spell spell);
    public event ModifyKnownSpells modifySpell;

    private MetricsSaveData metricsSaveData;

    public enum CastingStatus
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
        if(!knownSpells.Contains(newSpell))
            knownSpells.Add(newSpell);

        modifySpell?.Invoke(newSpell);
    }

    private void Start()
    {
        metricsSaveData = MetricsSaveData.instance;

    }

    private void Update()
    {
        if (LevelManager.instance.CantCast() || currentSpell == null)
            return;

        if (Input.GetKeyUp(KeyCode.Mouse0) )
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

    internal SpellCoolDown FindSpellCoolDown(Spell spell)
    {
        foreach (SpellCoolDown item in coolDowns)
        {
            if (item.spell == spell)
                return item;
        }
        return null;
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

    public void StopCasting()
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

        Debug.Log(" - " + currentSpell.spellName);
        metricsSaveData.metricsData.AddSpellUse(currentSpell.spellName);

        currentSpell.Cast(gameObject);
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
