using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItems : Interactable
{
    // Start is called before the first frame update

    public Item item;
    [SerializeField] float waitTime = 2f;

    public void OnPickUp()
    {
        bool added = Inventory.instance.AddItem(item);
        if (added)
            Destroy(gameObject);
        else
            ActivateObject();
    }


    public override void Interact()
    {
        OnPickUp();
    }

    IEnumerator ActivateObject()
    {
        yield return new WaitForSeconds(waitTime);
        hasInteracted = false;
    }
}
