using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellEfects
{
    public abstract void Effect(GameObject gameObject = null, ProjectileStats projectileStats = null);
}
