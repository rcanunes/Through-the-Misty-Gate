using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IgnoreInvisble : MonoBehaviour
{
    // Start is called before the first frame update
    private Image image;
    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
        if (image != null)
        {
            image.alphaHitTestMinimumThreshold = 0.01f;

        }
    }
}
