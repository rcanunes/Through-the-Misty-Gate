using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Radius Spell", menuName = "Spells/RadiusSpell")]
public class RadiusSpell : Spell
{

    public float radius;
    [SerializeField]
    public SpellEffect spellEffect;


    public override void Cast(GameObject player = null)
    {
        base.Cast(player);

        Collider2D[] affected = Physics2D.OverlapCircleAll(player.transform.position, radius);

        foreach (Collider2D item in affected)
        {
            if (item.CompareTag("Enemy"))
                spellEffect.EffectOnEnemy(item, player, player.GetComponent<PlayerStats>(), spellName);
            else
                spellEffect.Effect(item, player);
        }
    }
}
