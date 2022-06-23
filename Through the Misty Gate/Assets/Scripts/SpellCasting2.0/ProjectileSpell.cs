using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : Spell
{
    // Start is called before the first frame update
    GameObject projectile;
    ProjectileStats projectileStats;

    public override void Cast(GameObject player)
    {
        base.Cast(player);
        GameObject  proj = Instantiate(projectile);
        ProjectileBehaviour behaviour = proj.GetComponent<ProjectileBehaviour>();


        Vector3 origin = player.transform.position;
        origin.z = 0;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - origin;

        behaviour.SetUp(direction, projectileStats);

        player.GetComponent<PlayerController>().Knockback(projectileStats);

    }
}
