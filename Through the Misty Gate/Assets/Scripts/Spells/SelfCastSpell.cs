using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelfCastSpell : BaseSpell {
    protected SelfCastSpell(string name, float cooldown, float castTime, bool immobileCast) 
    : base(name, cooldown, castTime, immobileCast) {
    }

    public abstract void Cast();
}
