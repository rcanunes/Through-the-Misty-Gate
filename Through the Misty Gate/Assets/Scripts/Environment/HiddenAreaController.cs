using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenAreaController : MonoBehaviour
{

    public GameObject cover;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            cover.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            cover.SetActive(true);
    }
}
