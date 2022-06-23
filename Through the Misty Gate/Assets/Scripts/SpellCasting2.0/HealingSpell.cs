using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing Spell", menuName = "Spells/HealingSpell")]
public class HealingSpell : Spell
{
    public float amountHealed;
    public float healTime;

    public override void Cast(GameObject player)
    {
        base.Cast(player);
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.Heal((int)amountHealed, healTime);

    }

}
