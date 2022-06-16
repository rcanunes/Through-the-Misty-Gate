using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CinemachineVirtualCamera cinematicCamera;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cinematicCamera != null && collision.CompareTag("Player"))
        {
            cinematicCamera.Priority = 10;
            source.Play();
            StartCoroutine(LeaveCinemtaic());

        }
    }

    IEnumerator LeaveCinemtaic()
    {
        yield return new WaitForSeconds(7f);

        cinematicCamera.Priority = 0;
    }
}
