using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing Spell", menuName = "Spells/HealingSpell")]
public class HealingSpell : Spell
{
    public int amountHealed;
    public float healTime;
    public bool isExtraLife = false;

    public override void Cast(GameObject player)
    {
        base.Cast(player);
        PlayerStats stats = player.GetComponent<PlayerStats>();
        if (isExtraLife)
            stats.AddExtraLife(amountHealed);
        else
            stats.Heal(amountHealed, healTime);

    }

}
