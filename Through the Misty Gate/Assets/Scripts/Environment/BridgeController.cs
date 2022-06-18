using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        animator.SetBool("Open", true);

    }
}
