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
    private void AddForce(Collider2D item)
    {
        Vector2 targetPos = item.gameObject.transform.position;
        Vector2 sourcePos = gameObject.transform.position;

        Vector2 knockback = targetPos - sourcePos;

        item.gameObject.GetComponent<Rigidbody2D>().AddForce(knockback.normalized * 10, ForceMode2D.Impulse);


    }

    private void DealDamage(Collider2D item)
    {
        Debug.Log("Hit " + item.gameObject.name);
    }

    void ActivateSpell()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(gameObject.transform.position, radius);

        foreach (Collider2D item in targets)
        {
            if (item.CompareTag("Enemy"))
            {
                DealDamage(item);

            }

            if(!item.CompareTag("Player"))
                AddForce(item);
        }
        var aux = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(aux.gameObject, 1f);
        Destroy(gameObject);

    }
}
