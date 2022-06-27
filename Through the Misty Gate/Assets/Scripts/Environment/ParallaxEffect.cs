using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public GameObject camera;
    public float parallaxEffect;
    public float verticalDeslocation;
    private float startPos;
    private float posY;
    private float initialCamY;
    private float length;
    
    
    void Start()
    {
        startPos = transform.position.x;
        posY = transform.position.y;
        initialCamY = camera.transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    void FixedUpdate()
    {
        float camX = camera.transform.position.x;
        float temp = camX * (1 - parallaxEffect);
        float dist = camX * parallaxEffect;
        
        float camY = camera.transform.position.y;
        float diff = camY -initialCamY;
        //float height = (-camera.transform.position.y) * verticalDeslocation;

        transform.position = new Vector3(startPos + dist, posY + diff * verticalDeslocation, transform.position.z);

        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
}
