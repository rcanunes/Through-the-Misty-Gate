using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Spell")]
public class Spell: ScriptableObject
{
    public string spellName;
    public string description;
    public Sprite image;
    public float chargeTime;
    public float cooldown;
    public int knockback = 0;

    public bool canMoveOnCharge;
    public bool stopsMovementOnCharge;
    public bool damageStopsCasting;

    public virtual void Cast(GameObject player = null)
    {
        Debug.Log("Casting: " + spellName);
    }
}
