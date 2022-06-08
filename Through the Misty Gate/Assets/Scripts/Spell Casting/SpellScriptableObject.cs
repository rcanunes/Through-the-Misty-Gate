using UnityEngine;


[CreateAssetMenu(fileName = "SpellScriptableObject", menuName = "ScriptableObjects/Spell")]
public class SpellScriptableObject : ScriptableObject
{
    public string spellName = "Spell Name";
    public Sprite uiSprite;  // The sprite that will be shown in the hotbar/inventory
    public float cooldown = 1.0f;
    public float chargeTime;  // The amount of time the character is immobilized while casting
    public int spellId;
    public SpellEffectsScriptableObject spellEffects;


    public void Cast(MonoBehaviour caller, PlayerController player)
    {
        spellEffects.Cast(caller, player);
    }
    
}
