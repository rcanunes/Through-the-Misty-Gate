using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SpellCharging : MonoBehaviour
{
    // Start is called before the first frame update
    Slider slider;
    RectTransform rectTransform;

    void Awake()
    {
        slider = GetComponent<Slider>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        rectTransform.position = Input.mousePosition;
    }

    // Update is called once per frame
    public void SetCharger(float maxValue)
    {
        slider.value = 0;
        slider.maxValue = maxValue;
    }
    
    public void UpdateCharger(float value)
    {
        slider.value = value;
    }

    private void Update()
    {
        rectTransform.position = Input.mousePosition;
    }
}
