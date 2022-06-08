using UnityEngine;

/// <summary>
/// The projectile spell shoots a projectile at the target. The projectile travels through the air, not affected by gravity,
/// and is destroyed if it hits a wall or a platform.
///
/// It knockbacks player after being casted, the opposite direction in which it was casted.
///
/// If it's casted mid-air and it has a charge time, the player freezes in the air while casting.
/// </summary>
/// <param name="damage"> The number of health points the projectile damages the enemy on hit. </param>
/// <param name="speed"> The speed with which the projectile travels through the air. </param>
/// <param name="bulletsPerReload"> Instead of instantly going on cooldown, projectile spells can have a number of
/// casts allowed before going on cooldown, allowing for a reload mechanic. If this value is less or equal to 1,
/// the spell does not use the reload mechanic and goes instantly on cooldown. </param>
/// <param name="knockback"> The amount of displacement the player will suffer after casting the spell, in the opposite direction of the cast. </param>
/// <param name="projectilePrefab"> The prefab containing the sprite and collider for the projectile that will be spawned. </param>
/// 
[CreateAssetMenu(fileName = "ProjectileSpellEffectsScriptableObject", menuName = "ScriptableObjects/ProjectileSpellEffects")]
public class ProjectileSpellEffectsScriptableObject : SpellEffectsScriptableObject
{
    public int damage = 10;
    public float speed = 20.0f;  // Travel speed of the projectile
    public int bulletsPerReload; // if bullets <= 1, the spell goes instantly on cooldown after casting
    public float knockback = 2.0f;  // The amount of knockback that the player will suffer from casting the spell 
    
    // Prefab for the traveling projectile, should contain sprite, rigidbody and collider and be tagged 
    public GameObject projectilePrefab;  
    
    
    public override void Cast(CharacterController player)
    {
        
    }
}