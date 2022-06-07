using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefensiveSpell : BaseSpell {
    protected DefensiveSpell(string name, float cooldown, float castTime, float immobileCast) 
    : base(name, cooldown, castTime, immobileCast) {
        
    }
}
