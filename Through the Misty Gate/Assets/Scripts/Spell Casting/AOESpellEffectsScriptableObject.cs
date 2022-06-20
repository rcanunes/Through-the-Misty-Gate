using UnityEngine;

/// <summary>
/// AOE sell affects an area, either leaving an effect on the ground that lasts a certain amount of time,
/// or damaging the entities in the area instantly.
///
/// !!! The player has to be on the ground when casting an AOE spell. !!!
/// </summary>
/// 
/// <param name="damageOverTime"> How much damage is taken every second by enemy standing in the affected area. </param>
/// <param name="duration"> How long the effect stays on the ground, if duration = 0, the damage is instant. </param>
/// <param name="aoePrefab"> Prefab with the sprite and collider for the visual effects of the spell. Has to be spawned on the ground. </param>
/// 
[CreateAssetMenu(fileName = "AOESpellEffectsScriptableObject", menuName = "ScriptableObjects/AOESpellEffects")]
public class AOESpellEffectsScriptableObject : SpellEffectsScriptableObject {
    public int damageOverTime = 10;
    public float duration = 5.0f; // How long the effect stays on the ground, if duration = 0, the damage is instant

    // Prefab of the aoe spell, should contain a sprite and a collider and be tagged
    public GameObject aoePrefab;


    public override void Cast(MonoBehaviour caller, PlayerController player) {

    }
}
