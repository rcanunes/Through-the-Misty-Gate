using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    ProjectileStats projectileStats;
    public Rigidbody2D rb;

    // Update is called once per frame

    
    void Update()
    {
        Move();
       
    }

    private void Move()
    {
        float rotationZ = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        gameObject.transform.rotation = rotation;

    }

    internal void SetUp(Vector3 direction, ProjectileStats projectileStats)
    {
        this.projectileStats = projectileStats;
        rb = GetComponentInChildren<Rigidbody2D>();
        rb.velocity = direction * projectileStats.speed;
        rb.gravityScale = projectileStats.affectedByGravity;
        StartCoroutine(DestroyProjectile());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (projectileStats.stopsOnEnemies)
            {
                Destroy(gameObject);
                throw new NotImplementedException("Fucking Nunes doesnt give me enemies");
            }
        }

        else if (!collision.CompareTag("Player"))
        {
            if (projectileStats.stopsOnWalls)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(projectileStats.lifeTime);
        Destroy(gameObject);
    }

}
