using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinematicCamera;
    private AudioSource source;
    private bool hasHappened = false;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cinematicCamera != null && collision.CompareTag("Player") && !hasHappened)
        {
            cinematicCamera.Priority = 10;
            source.Play();
            StartCoroutine(LeaveCinemtaic());

        }
    }

    private void Disable()
    {
        hasHappened = true;
    }

    IEnumerator LeaveCinemtaic()
    {
        yield return new WaitForSeconds(7f);

        cinematicCamera.Priority = 0;
        Disable();
    }
}
