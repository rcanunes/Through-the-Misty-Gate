using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSoundController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] AudioSource bridgeSounds;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bridgeSounds.spatialBlend = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bridgeSounds.spatialBlend = 1;

    }
}
