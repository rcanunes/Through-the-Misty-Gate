using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    private int maxHitPoints = 1000;
    public int currentHitPoints;

    [SerializeField] HealthBar healthBar;
    [SerializeField] ParticleSystem healingParticles;

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

    bool healingParticlesON = false;

    private void Start()
    {
        currentHitPoints = maxHitPoints;
        healthBar.SetMaxHealth(maxHitPoints);

        armourModifier.baseValue = 100;
        healthModifer.baseValue = 100;
        baseDamageModifier.baseValue = 100;
        jumpModifier.baseValue = 100;
        speedModifier.baseValue = 100;
        fireDamageModifer.baseValue = 100;
        iceDamageModifier.baseValue = 100;

        EquipmentManager.instance.modifyEquipment += OnEquipItems;
    }

    void TakeDamage(int originalDamage)
    {
        int damage = (int) (originalDamage * armourModifier.GetValue());
        currentHitPoints -= damage;
        currentHitPoints = Mathf.Clamp(currentHitPoints, 0, maxHitPoints);

        healthBar.SetHealth(currentHitPoints);

        if (currentHitPoints == 0)
        {
            //die
        }

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
        healthBar.SetMaxHealth((int)(maxHitPoints * healthModifer.GetValue()));
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
            TakeDamage(800);    
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(1000, 1);    
        }

       


    }


    public void Heal(int heal, float timeToHeal = 0.01f)
    {
        currentHitPoints += heal;
        currentHitPoints = Mathf.Clamp(currentHitPoints, 0, maxHitPoints);

        healthBar.SetHealth(currentHitPoints, timeToHeal);

        PlayHealingParticles(timeToHeal);
    }

    private void PlayHealingParticles(float timeToHeal)
    {
        healingParticles.Stop();

        var duration = healingParticles.main;
        duration.duration = timeToHeal;

        healingParticles.Play();
    }
}
