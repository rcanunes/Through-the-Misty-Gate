using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItems : MonoBehaviour
{
    // Start is called before the first frame update

    public virtual void OnPickUp()
    {
        Debug.Log("Picking Up Item");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPickUp();
            Destroy(gameObject);
        }        
    }
}
