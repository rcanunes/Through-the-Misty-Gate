using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatePuzzleMaster : PuzzleMaster
{
    // Start is called before the first frame update
    [SerializeField] Transform gate;
    private AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Activate()
    {
        audioSource.PlayOneShot(audioClip, 0.2f);
        gate.gameObject.SetActive(false);
    }
}
