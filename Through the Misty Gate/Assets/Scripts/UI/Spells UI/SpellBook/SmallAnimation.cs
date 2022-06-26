using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAnimation : MonoBehaviour
{
    private RectTransform rt;
    public float targetPos;
    // Start is called before the first frame update

    private void Awake()
    {
        rt = gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(targetPos, rt.anchoredPosition.y);

    }
    private void OnEnable()
    {
        
        LeanTween.cancelAll();
        LeanTween.alpha(rt, 1f, 0.1f);
    }

    public void OnCLose()
    {
        LeanTween.cancelAll();
        LeanTween.alpha(rt, 0f, 0.1f).setOnComplete(Disable);
    }

    public void ResetAnimations()
    {
        LeanTween.cancelAll();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
