using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Spell")]
public class Spell: ScriptableObject
{
    public string spellName;
    public string description;
    public Sprite image;
    public float chargeTime;
    public float cooldown;
    public int knockback = 0;

    public bool cantMoveOnCharge;
    public bool stopsMovementOnCharge;
    public bool damageStopsCasting;

    public float shakeIntensityOnCast = 0;
    public float shakeDuration = 0;

    [SerializeField]
    public GameObject castingEffects = null;
    public float castingEffectsDuration = 2f;

    public virtual void Cast(GameObject player = null)
    {
        Debug.Log("Casting: " + spellName);


        if (castingEffects != null)
        {
            var aux = Instantiate(castingEffects, player.transform);
            Destroy(aux.gameObject, castingEffectsDuration);
        }

        if (shakeIntensityOnCast > 0)
        {
            CameraShake.instance.Shake(shakeIntensityOnCast, shakeDuration);
        }
    }
}
