using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (uiObject != null)
        {
            uiObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(uiObject);
    }
}
