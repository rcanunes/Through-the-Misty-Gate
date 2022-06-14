using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : PuzzleKey
{

    //Audio
    private AudioSource audioSource;
    public AudioClip tickSound;
    public AudioClip resetSound;


    //Animation
    private Transform arm;
    private SpriteRenderer shereRenderer;

    private int time;

    void Start()
    {
        time = 6;
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
        StartCoroutine(TimedReturn(time));
    }

    private void Deactivate()
    {
        active = false;
        VisualUpdate();
        PlaySound();

    }

    private void PlaySound()
    {
        if (done)
        {
            return;
        }

        if(active)
            audioSource.PlayOneShot(tickSound, 1);
        else
            audioSource.PlayOneShot(resetSound, 1);

    }

    IEnumerator TimedReturn(int length)
    {
        for (int i = 0; i < length; i++)
        {
            PlaySound();
            yield return new WaitForSeconds(1.5f);
        }
        if (!done)
        {
            Deactivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Banana");
        if (collision.CompareTag("Player") || collision.CompareTag("Spell"))
        {
            if (!active)
            {
                Activate();
            }
        }
    }
}

