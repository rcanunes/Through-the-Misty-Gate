using UnityEngine;


[CreateAssetMenu(fileName = "ProjectileSpellEffectsScriptableObject", menuName = "ScriptableObjects/ProjectileSpellEffects")]
public class ProjectileSpellEffectsScriptableObject : SpellEffectsScriptableObject
{
    public int damage = 10;
    public float speed = 20.0f;  // Travel speed of the projectile
    public int bulletsPerReload; // if bullets <= 1, the spell goes instantly on cooldown after casting
    public float knockback = 2.0f;  // The amount of knockback that the player will suffer from casting the spell 
    
    // Prefab for the traveling projectile, should contain sprite, rigidbody and collider and be tagged 
    public GameObject projectilePrefab;  
}
