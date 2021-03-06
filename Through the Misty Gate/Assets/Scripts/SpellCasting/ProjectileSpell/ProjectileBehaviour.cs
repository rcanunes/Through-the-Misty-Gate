using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    protected ProjectileStats projectileStats;
    Rigidbody2D rb;
    PlayerStats playerStats;
    string spellName;

    // Update is called once per frame

    
    void Update()
    {
        if(projectileStats.affectedByGravity != 0)
            Move();
       
    }

    private void Move()
    {
        float rotationZ = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        gameObject.transform.rotation = rotation;

    }

    internal void SetUp(Vector3 direction, ProjectileStats projectileStats, string spellName)
    {
        this.spellName = spellName;
        this.projectileStats = projectileStats;
        rb = GetComponentInChildren<Rigidbody2D>();
        rb.velocity = direction * projectileStats.speed;
        rb.gravityScale = projectileStats.affectedByGravity;
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        StartCoroutine(DestroyProjectile());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Affect(collision);
        }


    }

    private void Affect(Collider2D collision)
    {
        if(projectileStats.radius == 0 && collision.CompareTag("Enemy"))
        {
            projectileStats.spellEffects.EffectOnEnemy(collision, gameObject, playerStats, spellName);

            if (projectileStats.stopsOnEnemies)
                ProjectileCollision();
        }
        else if (projectileStats.radius == 0)
        {
            if (projectileStats.stopsOnWalls && !collision.CompareTag("Trigger"))
                ProjectileCollision();
        }
        else
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, projectileStats.radius);

            foreach (Collider2D collider in colliders)
            {
                if(collider.CompareTag("Enemy"))
                    projectileStats.spellEffects.EffectOnEnemy(collider, gameObject, playerStats, spellName);
                else
                    projectileStats.spellEffects.Effect(collider, gameObject);

            }

            
            ProjectileCollision();
        }
    }

    private void ProjectileCollision()
    {
        if(projectileStats.spellEfectsOnCollision != null) {
            Vector3 position = transform.position;
            var aux = Instantiate(projectileStats.spellEfectsOnCollision, transform.position, transform.rotation);
            Debug.Log(position.ToString() + transform.rotation.ToString());
            Destroy(aux.gameObject, 1f);
        }
            
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, projectileStats.radius > 0? 0.1f : projectileStats.radius);
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(projectileStats.lifeTime);
        Destroy(gameObject);
    }

}
