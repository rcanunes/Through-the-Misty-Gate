using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using Player;

namespace Spell_Casting {
    [CreateAssetMenu(fileName = "SpellScriptableObject", menuName = "ScriptableObjects/Spell")]
    public class SpellScriptableObject : ScriptableObject {
        public string spellName = "Spell Name";
        public Sprite uiSprite; // The sprite that will be shown in the hotbar/inventory
        public float cooldown = 1.0f;
        public float chargeTime; // The amount of time the character is immobilized while casting
        public int spellId;
        public string spellDescription;
        public SpellEffectsScriptableObject spellEffects;


        public void Cast(MonoBehaviour caller, PlayerController player) {
            if (chargeTime > 0) {
                player.EnterChargedCast(chargeTime);
                caller.StartCoroutine(WaitForCharge(caller, player));
                return;
            }

            spellEffects.Cast(caller, player);
        }

        private IEnumerator WaitForCharge(MonoBehaviour caller, PlayerController player) {
            yield return new WaitForSeconds(chargeTime);
            spellEffects.Cast(caller, player);
        }

    }
}