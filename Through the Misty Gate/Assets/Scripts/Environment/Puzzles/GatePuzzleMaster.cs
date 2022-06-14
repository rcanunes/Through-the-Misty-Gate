using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatePuzzleMaster : PuzzleMaster
{
    // Start is called before the first frame update
    private Animator gateAnimator;
    private AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gateAnimator = transform.Find("Gate").GetComponent<Animator>();
    }

    public override void Activate()
    {
        audioSource.PlayOneShot(audioClip, 0.2f);
        gateAnimator.SetBool("Open", true);
        enabled = false;
    }
}
