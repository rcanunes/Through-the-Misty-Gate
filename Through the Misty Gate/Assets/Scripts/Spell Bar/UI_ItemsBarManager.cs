using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ItemsBarManager : MonoBehaviour
{
    // Update is called once per frame


    [SerializeField] Spells player;
    [SerializeField] UI_HotKeyBar uiHotKeyBar;

    private HotKeySystem hotKeySystem;

    private void Start()
    {
        hotKeySystem = new HotKeySystem(player);
        uiHotKeyBar.SetHotKeySystem(hotKeySystem);
    }

    void Update()
    {
        hotKeySystem.Update();
    }
}
