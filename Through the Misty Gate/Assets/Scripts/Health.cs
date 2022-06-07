using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private float curHealth;

    public Health(float maxHp) {
        maxHealth = maxHp;
    }

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float maxHealth { get; set;}

    public float GetCurrentHealth() {
        return curHealth;
    }

    public void HealEntity(int hp) {
        curHealth = (curHealth + hp < maxHealth) ? curHealth + hp : maxHealth;
        healthBar.SetHealth(curHealth);
    }

    public void DamageEntity(int hp) {
        curHealth = (curHealth - hp > 0) ? curHealth - hp : 0;
        healthBar.SetHealth(curHealth);
    }
}
