using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private bool visibleInventory;

    private void Awake()
    {
        instance = this;
        visibleInventory = false;
    }

    public bool CanClick()
    {
        return !visibleInventory;
    }

    public void SetInventoryVisivility(bool visible)
    {
        visibleInventory = visible;
    }
}
