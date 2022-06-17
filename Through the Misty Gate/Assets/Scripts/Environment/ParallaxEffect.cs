using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public GameObject camera;
    public float parallaxEffect;
    private float startPos;
    private float length;
    
    
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    void FixedUpdate()
    {
        float temp = camera.transform.position.x * (1 - parallaxEffect);
        float dist = camera.transform.position.x * parallaxEffect;

        transform.position = new Vector3(dist, transform.position.y, transform.position.z);

        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
}
