using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{



    private int maxHitPoints = 1000;
    public int currentHitPoints;

    [SerializeField] HealthBar healthBar;

    private void Start()
    {
        currentHitPoints = maxHitPoints;
        healthBar.SetMaxHealth(maxHitPoints);
    }

    void TakeDamage(int damage)
    {
        currentHitPoints -= damage;

        healthBar.SetHealth(currentHitPoints);

        if (currentHitPoints <= 0)
        {
            //die
        }

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);    
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(20);    
        }


    }


    void Heal(int heal)
    {
        currentHitPoints += heal;

        healthBar.SetHealth(currentHitPoints);

        if (currentHitPoints >= maxHitPoints)
        {
            currentHitPoints = maxHitPoints;
        }
    }

}
