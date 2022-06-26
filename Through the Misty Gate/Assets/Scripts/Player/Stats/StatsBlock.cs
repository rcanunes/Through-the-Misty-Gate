using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsBlock{
    [SerializeField]
    public int healthModifer;
    [SerializeField]
    public int armourModifier;
    [SerializeField]
    public int baseDamageModifier;
    [SerializeField]
    public int jumpModifier;
    [SerializeField]
    public int speedModifier;
    [SerializeField]
    public int fireDamageModifer;
    [SerializeField]
    public int iceDamageModifier;
    [SerializeField]
    public bool iceBootsModifier;
    [SerializeField]
    public bool doubleJumpModifier;
    [SerializeField]
    public bool grabWallModifier;
}
