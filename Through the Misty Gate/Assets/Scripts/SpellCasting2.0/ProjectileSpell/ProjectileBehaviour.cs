using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    Vector3 direction;
    ProjectileStats projectileStats;
    public Rigidbody2D rb;

    // Update is called once per frame

    
    void Update()
    {
        Move();
       
    }

    private void Move()
    {
        rb.velocity = direction;
    }

    internal void SetUp(Vector3 direction, ProjectileStats projectileStats)
    {
        this.direction = direction;
        this.projectileStats = projectileStats;
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            Debug.Log("Hit");
        }
    }
}
