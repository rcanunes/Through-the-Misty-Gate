using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UI_ChargeViewer : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _image;

    // Update is called once per frame
    public void UpdateImage()
    {
        _image.color = _gradient.Evaluate(_image.fillAmount);
    }
}
