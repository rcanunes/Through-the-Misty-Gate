using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int newHealh)
    {
        healthBar.value = newHealh;
        fill.color = gradient.Evaluate(healthBar.value / healthBar.maxValue);
    }

}
