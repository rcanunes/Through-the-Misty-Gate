using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffSpell : SelfCastSpell {
    private float buffValue;

    protected BuffSpell(string name, float cooldown, float castTime, bool immobileCast, float buffValue) 
    : base(name, cooldown, castTime, immobileCast) {
        this.buffValue = buffValue;
    }
}
