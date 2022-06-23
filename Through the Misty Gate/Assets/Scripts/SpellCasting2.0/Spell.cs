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
    public bool canMoveOnCharge;
    public int knockback;
    public bool stopsMovementOnCharge;

    public virtual void Cast(GameObject player)
    {
        Debug.Log("Casting: " + spellName);
    }
}
