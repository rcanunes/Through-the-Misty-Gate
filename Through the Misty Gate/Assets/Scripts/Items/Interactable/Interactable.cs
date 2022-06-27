using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    protected GameObject player;
    public bool hasInteracted;

    private void Awake()
    {
        hasInteracted = false;
        player = GameObject.FindWithTag("Player");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Update()
    {
        if (!hasInteracted)
        {
            float dist = Vector2.Distance(player.transform.position, transform.position);

            if (dist <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
    
    }
}
