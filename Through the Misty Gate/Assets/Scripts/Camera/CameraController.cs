using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    [SerializeField] private Vector2 offset = new Vector2(0,0);
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y+offset.y, transform.position.z);
    }
}
