using UnityEngine;


[CreateAssetMenu(fileName = "AOESpellEffectsScriptableObject", menuName = "ScriptableObjects/AOESpellEffects")]
public class AOESpellEffectsScriptableObject : SpellEffectsScriptableObject
{
    public int damageOverTime = 10;
    public float duration = 5.0f;  // How long the effect stays on the ground

    // Prefab of the aoe spell, should contain a sprite and a collider and be tagged
    public GameObject aoePrefab;
}
