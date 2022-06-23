using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    Vector3 direction;
    ProjectileStats projectileStats;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        throw new NotImplementedException();
    }

    internal void SetUp(Vector3 direction, ProjectileStats projectileStats)
    {
        this.direction = direction;
        this.projectileStats = projectileStats;
    }
}
