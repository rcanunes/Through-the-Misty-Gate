using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BurstHealSpell : SupportSpell {
    public BurstHealSpell(string name, float cooldown, float castTime, float immobileCast) 
    : base(name, cooldown, castTime, immobileCast) {
        
    }

    public override void Cast() {
        
    }
}
