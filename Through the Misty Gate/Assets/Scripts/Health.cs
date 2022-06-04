using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float curHealth = 0.0f;
    public float burstRate = 1.5f;
    private float nextBurst = 0.0f;
    private float nextDamage = 0.0f;
    public float damageRate = 2.0f;
    public Image m1Image;
    public Image m2Image;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        m1Image = GameObject.FindGameObjectWithTag("M1").GetComponent<Image>();
        m2Image = GameObject.FindGameObjectWithTag("M2").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
