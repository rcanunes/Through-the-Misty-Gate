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
    public float healDuration; // How long does it take to heal the amount? 0 = instant heal
    
    public override void Cast(CharacterController player)
    {
        
    }
}
