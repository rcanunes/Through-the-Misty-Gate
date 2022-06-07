using UnityEngine;


[CreateAssetMenu(fileName = "HealSpellEffectsScriptableObject", menuName = "ScriptableObjects/HealSpellEffects")]
public class HealSpellEffectsScriptableObject : SpellEffectsScriptableObject
{
    public int healAmount = 50;
    public float healDuration; // How long does it take to heal the amount? 0 = instant heal
}
