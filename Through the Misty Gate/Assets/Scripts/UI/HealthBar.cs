using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    private int targetHealth;
    private float slowHealth;
    private float originHealth;
    private float t;
    private float timeToReach;
    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int newHealh, float time = 0.1f)
    {
        originHealth = healthBar.value;
        targetHealth = newHealh;
        t = 0;
        timeToReach = time;
    }

    private void Update()
    {
        if(slowHealth != targetHealth)
        {
            t += Time.deltaTime / timeToReach;
            slowHealth = Mathf.Lerp(originHealth, targetHealth, t);
            healthBar.value = slowHealth;
            fill.color = gradient.Evaluate(healthBar.value / healthBar.maxValue);
        }
        
    }

}
