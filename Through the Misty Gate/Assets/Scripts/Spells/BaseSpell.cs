using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MonoBehaviour {
    private string label;
    private float cooldown;
    private float castTime;
    private bool immobileCast;

    protected BaseSpell(string label, float cooldown, float castTime, float immobileCast) {
        this.label = label;
        this.cooldown = cooldown;
        this.castTime = castTime;
        this.immobileCast = immobileCast;
    }

    public string getLabel() {
        return this.label;
    }

    public float getCooldown() {
        return this.cooldown;
    }

    public float getCastTime() {
        return this.castTime;
    }

    public bool getImmobileCast() {
        return this.immobileCast;
    }

    protected IEnumerator ChargeAttack() {
        yield return new WaitForSeconds(chargeTime);
        rb.velocity = direction * speed;
    }
}
