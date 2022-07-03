using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private int maxHitPoints = 1000;
    public int currentHitPoints;

    private int maxExtraHitPoints = 1000;
    private int extraLifePoints;

    [SerializeField] HealthBar healthBar;
    [SerializeField] HealthBar extraLife;
    [SerializeField] ParticleSystem healingParticles;
    private SpriteRenderer image;

    private RespawnPlayer _respawnPlayer;

    MetricsSaveData metricsSaveData;
    SpellCaster spellCaster;

    public Stat healthModifer;
    public Stat baseDamageModifier;
    public Stat jumpModifier;
    public Stat speedModifier;
    public Stat armourModifier;

    public Stat fireDamageModifer;
    public Stat iceDamageModifier;

    public BoolStat iceBootsModifier;
    public BoolStat doubleJumpModifier;
    public BoolStat grabWallModifier;


    private void Start()
    {
        image = GetComponent<SpriteRenderer>();
        metricsSaveData = MetricsSaveData.instance;
        currentHitPoints = maxHitPoints;
        healthBar.SetMaxHealth(maxHitPoints, currentHitPoints);

        extraLife.SetMaxHealth(maxExtraHitPoints, 0);

        armourModifier.baseValue        = 100;
        healthModifer.baseValue         = 100;
        baseDamageModifier.baseValue    = 100;
        jumpModifier.baseValue          = 100;
        speedModifier.baseValue         = 100;
        fireDamageModifer.baseValue     = 100;
        iceDamageModifier.baseValue     = 100;

        EquipmentManager.instance.modifyEquipment += OnEquipItems;

        spellCaster = GetComponent<SpellCaster>();

        _respawnPlayer = transform.GetComponent<RespawnPlayer>();

        transform.position = _respawnPlayer.spawnPoint.transform.position;

    }

    public void TakeDamage(int originalDamage, string enemyType)
    {
        int damage = (int) (originalDamage * armourModifier.GetValue());

        metricsSaveData.metricsData.AddEnemyDamage(enemyType, damage);

        if (extraLifePoints != 0)
        {
            if (damage > extraLifePoints)
            {
                damage -= extraLifePoints;
                extraLifePoints = 0;
            }

            else
            {
                extraLifePoints -= damage;
                damage = 0;
            }

            extraLife.SetHealth(extraLifePoints);
        }


        currentHitPoints -= damage;
        currentHitPoints = Mathf.Clamp(currentHitPoints, 0, maxHitPoints);

        healthBar.SetHealth(currentHitPoints);

        if (currentHitPoints == 0)
        {
            Die();
            metricsSaveData.metricsData.AddEnemyKills(enemyType);
            metricsSaveData.metricsData.AddDeathCount();

        }
        else
        {
            StartCoroutine(Flicker());
        }

        if (spellCaster.currentSpell != null)
            if(spellCaster.currentSpell.damageStopsCasting)
                spellCaster.StopCasting();

    }

    private void Die()
    {
        currentHitPoints = maxHitPoints;
        healthBar.SetHealth(currentHitPoints, 0.1f);
        _respawnPlayer.Respawn();
    }

    public void AddExtraLife(int newPoints)
    {
        float originalExtraLife = extraLifePoints;

        if(extraLifePoints != 0)
        {
            if (newPoints > extraLifePoints)
                extraLifePoints = newPoints;
        }
        else
        {
            extraLifePoints = newPoints;
        }

        extraLife.SetHealth(extraLifePoints);

        metricsSaveData.metricsData.AddSpellHeal(spellCaster.currentSpell.spellName, extraLifePoints -  originalExtraLife);


    }

    public void OnEquipItems(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
            AddModifiers(newItem.modifiers);

        if(oldItem != null)
            RemoveModifiers(oldItem.modifiers);

        SetMaxHitPoints();
    }

    void SetMaxHitPoints()
    {
        healthBar.SetMaxHealth((int)(maxHitPoints * healthModifer.GetValue()), currentHitPoints);
    }

    private void RemoveModifiers(StatsBlock modifiers)
    {
        healthModifer.RemoveModifier(modifiers.healthModifer);
        baseDamageModifier.RemoveModifier(modifiers.baseDamageModifier);
        jumpModifier.RemoveModifier(modifiers.jumpModifier);
        speedModifier.RemoveModifier(modifiers.speedModifier);

        fireDamageModifer.RemoveModifier(modifiers.fireDamageModifer);
        iceDamageModifier.RemoveModifier(modifiers.iceDamageModifier);

        iceBootsModifier.RemoveModifier(modifiers.iceBootsModifier);
        doubleJumpModifier.RemoveModifier(modifiers.doubleJumpModifier);
        grabWallModifier.RemoveModifier(modifiers.grabWallModifier);
    }

    private void AddModifiers(StatsBlock modifiers)
    {
        healthModifer.AddModifier(modifiers.healthModifer);
        baseDamageModifier.AddModifier(modifiers.baseDamageModifier);
        jumpModifier.AddModifier(modifiers.jumpModifier);
        speedModifier.AddModifier(modifiers.speedModifier);

        fireDamageModifer.AddModifier(modifiers.fireDamageModifer);
        iceDamageModifier.AddModifier(modifiers.iceDamageModifier);

        iceBootsModifier.AddModifier(modifiers.iceBootsModifier);
        doubleJumpModifier.AddModifier(modifiers.doubleJumpModifier);
        grabWallModifier.AddModifier(modifiers.grabWallModifier);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(50, "suicide");    
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(1000, 1);    
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddExtraLife(300);    
        }

    }


    public void Heal(int heal, float timeToHeal = 0.01f)
    {

        float originalHitPonts = currentHitPoints;

        currentHitPoints += heal;
        currentHitPoints = Mathf.Clamp(currentHitPoints, 0, maxHitPoints);

        healthBar.SetHealth(currentHitPoints, timeToHeal);


        metricsSaveData.metricsData.AddSpellHeal(spellCaster.currentSpell.spellName, currentHitPoints - originalHitPonts);

        PlayHealingParticles(timeToHeal);
    }

    private void PlayHealingParticles(float timeToHeal)
    {
        healingParticles.Stop();

        var duration = healingParticles.main;
        duration.duration = timeToHeal;

        healingParticles.Play();
    }

    IEnumerator Flicker()
    {
        image.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        image.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        image.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        image.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        image.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        image.color = Color.white;
    }
}
