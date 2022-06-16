using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBreak : MonoBehaviour
{
    [SerializeField] Joint2D joint;

    private AudioSource source;
    [SerializeField] private AudioSource bridgeSounds;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && joint.enabled)
        {
            source.Play();
            StartCoroutine(SnapBridge());
        }
    }

    IEnumerator SnapBridge()
    {
        yield return new WaitForSeconds(0.5f);
        joint.enabled = false;
        bridgeSounds.enabled = false;
    }
}
