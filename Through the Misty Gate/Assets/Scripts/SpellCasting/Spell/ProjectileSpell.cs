using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Spell", menuName = "Spells/ProjectileSpell")]
public class ProjectileSpell : Spell
{
    // Start is called before the first frame update
    [SerializeField]
    ProjectileStats projectileStats;

    public override void Cast(GameObject player)
    {
        base.Cast(player);
        
        Vector3 direction = GetDirection(player);
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        GameObject proj = Instantiate(projectileStats.projectile, player.transform.position, rotation);

        ProjectileBehaviour behaviour = proj.GetComponent<ProjectileBehaviour>();
        behaviour.SetUp(direction, projectileStats, spellName);

        Vector3 aux = direction * -1;
        Vector2 knockbackVector = new Vector2(aux.x, aux.y) * knockback;

        player.GetComponent<PlayerController>().KnockBack(knockbackVector);

    }

    private static Vector3 GetDirection(GameObject player)
    {
        Vector3 origin = player.transform.position;
        origin.z = 0;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = mousePosition - origin;
        return direction.normalized;
    }
}
