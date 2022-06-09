using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealSpell : SelfCastSpell {
    public HealSpell(string name, float cooldown, float castTime, bool immobileCast) 
    : base(name, cooldown, castTime, immobileCast) {
        
    }

    public override void Cast() {
        
    }
}
