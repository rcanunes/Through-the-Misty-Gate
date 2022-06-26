﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Effects", menuName = "Spells/SpellEffects")]

public class SpellEffect: ScriptableObject
{
    public float damage = 0;
    public float knockback = 0;
    public DamageTypes damageType = DamageTypes.Default;
    //TODO: Debuffs

    public void EffectOnEnemy(Collider2D enemy, GameObject projectile, PlayerStats player, string spellName)
    {
        Effect(enemy, projectile);
        if (damage > 0)
            DealDamage(enemy, player, spellName);

        //Todo: debufss

        

    }

    public void Effect(Collider2D enemy, GameObject projectile)
    {
        if (knockback > 0)
            AddForce(enemy, projectile);

    }

    private void DealDamage(Collider2D enemy, PlayerStats player, string spellName)
    {
        damage *= player.baseDamageModifier.GetValue();
        if (damageType == DamageTypes.Fire)
            damage *= player.fireDamageModifer.GetValue();
        else if(damageType == DamageTypes.Ice)
            damage *= player.iceDamageModifier.GetValue();

        Debug.Log("Hit " + enemy.gameObject.name + "  Damage: " + damage);

        //MetricStuff
        MetricsSaveData.instance.metricsData.AddSpellDamage(spellName, damage);
        MetricsSaveData.instance.metricsData.AddSpellEnemyHit(spellName);
        EquipmentManager.instance.AddDamageDEaltWhileEquiped(damage);


    }

    private void AddForce(Collider2D enemy, GameObject projectile)
    {
        Vector2 targetPos = enemy.transform.position;
        Vector2 sourcePos = projectile.transform.position;
        Vector2 knockbackDirection = targetPos - sourcePos;
        knockbackDirection.Normalize();
        Rigidbody2D rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        if(rb != null)
            rb.AddForce(knockbackDirection * knockback, ForceMode2D.Impulse);

        Debug.Log("Adding Force to " + enemy.gameObject.name + "  Knocjvac: " + knockback);


    }
}

public enum DamageTypes
{
    Fire,
    Ice,
    Default
}