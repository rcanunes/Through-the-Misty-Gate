using System.Collections;
using UnityEngine;

/// <summary>
/// Heal Spell affects only the player. Restores health.
/// If it doesn't have a charge time, it can be casted while moving or while in the air.
/// </summary>
/// <param name="healAmount"> Amount of health points that will be restored to the player. </param>
/// <param name="healDuration"> How long, in seconds, does it take to heal the healAmount? 0 = instant heal </param>
/// 
[CreateAssetMenu(fileName = "HealSpellEffectsScriptableObject", menuName = "ScriptableObjects/HealSpellEffects")]
public class HealSpellEffectsScriptableObject : SpellEffectsScriptableObject
{
    public int healAmount = 50;
    public float healDuration; // How long does it take to heal the amount? If <= 1, instant heal


    public override void Cast(MonoBehaviour caller, PlayerController player)
    {
        if (healDuration <= 1)
        {
            //player.Heal(healAmount);   // TODO implement Heal() on PlayerController
            return;
        }

        float healBit = healAmount / healDuration;   // Heal a bit every 1s
        caller.StartCoroutine(HealOverTime(player, healBit));
      
    }

    public IEnumerator HealOverTime(PlayerController player, float healBit)
    {
        float healed = 0;

        while (healed < healAmount)
        {
            //player.Heal(healBit);  // TODO 
            healed += healBit;
            yield return new WaitForSeconds(1);
        }
    }
}
