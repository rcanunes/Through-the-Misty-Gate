using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SupportSpell : BaseSpell {
    protected SupportSpell(string name, float cooldown, float castTime, float immobileCast) 
    : base(name, cooldown, castTime, immobileCast) {

    }
}
