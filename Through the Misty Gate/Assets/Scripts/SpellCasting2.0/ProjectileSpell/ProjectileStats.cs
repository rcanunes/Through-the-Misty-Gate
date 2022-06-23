using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Stats", menuName = "Spells/ProjectileStats")]
public class ProjectileStats : ScriptableObject
{
    public bool affectedByGravity = false;
    public float speed = 1;
    public float damage = 1;
    public int bulletsPerReload = 1;

    [SerializeField]
    public GameObject projectile;

}
