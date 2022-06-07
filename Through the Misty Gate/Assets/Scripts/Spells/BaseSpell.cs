using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MonoBehaviour {
    private string name;
    private float cooldown;
    private float castTime;
    private bool immobileCast;

    protected Spell(string name, float cooldown, float castTime, float immobileCast) {
        this.name = name;
        this.cooldown = cooldown;
        this.castTime = castTime;
        this.immobileCast = immobileCast;
    }

    public string getName() {
        return this.name;
    }

    public float getCooldown() {
        return this.cooldown;
    }

    public float castTime() {
        return this.castTime;
    }

    public bool immobileCast() {
        return this.immobileCast;
    }

    public abstract void Cast();
}
