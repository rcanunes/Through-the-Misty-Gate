using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Stats", menuName = "Spells/ProjectileStats")]
public class ProjectileStats : ScriptableObject
{
    public float affectedByGravity = 0;
    public float speed = 1;
    public int bulletsPerReload = 1;

    public bool stopsOnEnemies = true;
    public bool stopsOnWalls = true;
    public float lifeTime = 10f;

    public float radius = 0;

    [SerializeField]
    public GameObject projectile;

    [SerializeField]
    public GameObject spellEfectsOnCollision = null;

    [SerializeField]
    public SpellEffect spellEffects;
    
    

}
