using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileSpell : BaseSpell {
    private float damage;
    private float speed;
    private float areaOfEffect;
    private Vector3 direction;
    private Rigidbody2D rb = null; 

    protected ProjectileSpell(string name, float cooldown, float castTime, float immobileCast, float damage, float speed, float areaOfEffect) 
    : base(name, cooldown, castTime, immobileCast) {
        this.damage = damage;
        this.speed = speed;
        this.areaOfEffect = areaOfEffect;
    }

    public float getDamage() {
        return this.damage;
    }

    public float getSpeed() {
        return this.speed;
    }

    public float getAoe() {
        return this.areaOfEffect;
    }

    public abstract void Cast(Vector3 position, Vector3 target);
}
