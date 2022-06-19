using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : PuzzleKey
{

    //Audio
    private AudioSource audioSource;
    public AudioClip tickSound;
    public AudioClip resetSound;


    //Animation
    private Transform arm;
    private SpriteRenderer shereRenderer;
    private bool canAction;

    void Start()
    {
        canAction = true;
        audioSource = GetComponent<AudioSource>();
        arm = transform.Find("Arm");
        shereRenderer = arm.Find("Handle").GetComponent<SpriteRenderer>();
        active = false;
        VisualUpdate();
    }

    private void VisualUpdate()
    {
        if (active)
        {
            arm.localEulerAngles = new Vector3(0, 0, 30);
            shereRenderer.color = Color.green;

        }

        else
        {
            arm.localEulerAngles = new Vector3(0, 0, -30);
            shereRenderer.color = Color.red;

        }
    }

    // Update is called once per frame

    private void Activate()
    {
        active = true;
        VisualUpdate();
        PlaySound();
    }

    private void Deactivate()
    {
        active = false;
        VisualUpdate();
        PlaySound();

    }

    private void PlaySound()
    {
        audioSource.PlayOneShot(tickSound, 1);

    }

    IEnumerator StopMoving()
    {
        canAction = false;
        yield return new WaitForSeconds(1f);
        canAction = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("Spell")) && canAction)
        {
            if (!active)
            {
                Activate();
            }

            else
            {
                Deactivate();
            }
        }
    }
}

