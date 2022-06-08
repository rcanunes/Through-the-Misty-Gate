using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellCastingManager : MonoBehaviour
{
    private PlayerController _player;
    private SpellScriptableObject[] _unlockedSpells;  // Use array for quick lookup
    
    
    [SerializeField] private List<string> startingSpells;  // Names of the starting spells - must match the name in the asset
    [SerializeField] private SpellsDatabase spellsDatabase;
    
    private int currentSpellId = 0;

    
    void Awake()
    {
        // Assign character controller
        _player = transform.GetComponent<PlayerController>();
        
        
        // Assign starting spells to unlocked spells
        spellsDatabase.AssertCorrectIDs();
        
        int maxSpells = spellsDatabase.spells.Capacity;
        _unlockedSpells = new SpellScriptableObject[maxSpells];
        
        // Guarantee that the number of starting spells does not exceed the capacity
        if (startingSpells.Count > maxSpells)
        {
            Debug.LogError("Too many starting spells or not enough spells in the database");
            Debug.Break();
        }
        
        // Lookup spells by name
        foreach (var spellName in startingSpells)
        {
            foreach (var spell in spellsDatabase.spells)
            {
                if (spell.name == spellName)
                    _unlockedSpells[spell.spellId] = spell;
            }
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CastSpell()
    {
        _unlockedSpells[currentSpellId].Cast(this, _player);
    }

    public SpellScriptableObject GetCurrentSpell()
    {
        return _unlockedSpells[currentSpellId];
    }
    
}
