using UnityEngine;
using Player;

namespace Spell_Casting {
  public abstract class SpellEffectsScriptableObject : ScriptableObject {
    // Parent class for specialized spells
    public abstract void Cast(MonoBehaviour caller, PlayerController player);
  }
}