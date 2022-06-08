using UnityEngine;

public abstract class SpellEffectsScriptableObject : ScriptableObject
{
  // Parent class for specialized spells
  public abstract void Cast(CharacterController player);
}
