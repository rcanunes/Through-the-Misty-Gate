using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OffensiveSpell : BaseSpell {
    private float damage;
    private float speed;
    private float areaOfEffect;
    private Vector3 direction;
    private Rigidbody2D rb = null; 

    protected OffensiveSpell(string name, float cooldown, float castTime, float immobileCast, float damage, float speed, float areaOfEffect) 
    : base(name, cooldown, castTime, immobileCast) {
        this.damage = damage;
        this.speed = speed;
        this.areaOfEffect = areaOfEffect;
    }

    public abstract void Cast();

    private IEnumerator ChargeAttack()
    {
        yield return new WaitForSeconds(chargeTime);
        rb.velocity = direction * speed;
    }
}
