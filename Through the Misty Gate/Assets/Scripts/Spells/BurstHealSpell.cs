using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BurstHealSpell : SelfCastSpell {
    public BurstHealSpell(string name, float cooldown, float castTime, bool immobileCast) 
    : base(name, cooldown, castTime, immobileCast) {
        
    }
}
