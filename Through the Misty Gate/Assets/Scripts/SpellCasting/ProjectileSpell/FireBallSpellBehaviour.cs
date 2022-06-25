using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpellBehaviour : ProjectileBehaviour
{
    [SerializeField] float radius;
    [SerializeField] Transform explosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {


       if (!collision.CompareTag("Player"))
        {
            if (projectileStats.stopsOnWalls || projectileStats.stopsOnEnemies)
            {
                ActivateSpell();
                

                throw new NotImplementedException("Fucking Nunes doesnt give me enemies");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void ActivateSpell()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(gameObject.transform.position, radius);

        
        

    }
}
