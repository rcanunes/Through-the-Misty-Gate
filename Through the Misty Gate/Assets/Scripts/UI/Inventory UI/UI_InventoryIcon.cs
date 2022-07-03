using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryIcon : MonoBehaviour
{
    Inventory inventory;
    Image image;
    AudioSource source;
    void Start()
    {
        inventory = Inventory.instance;
        image = GetComponent<Image>();
        source = GetComponent<AudioSource>();
        inventory.AddToInventory += Inventory_ModifyInventory;
    }

    private void Inventory_ModifyInventory()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        source.Play();
        image.color = new Color(1f, 1f, 0f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        image.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        image.color = new Color(1f, 1f, 0f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        image.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        image.color = new Color(1f, 1f, 0f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        image.color = Color.white;
    }
}
