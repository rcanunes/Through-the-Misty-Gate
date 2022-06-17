using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAnimation : MonoBehaviour
{
    private RectTransform rt;
    private float startPos;
    public float targetPos;
    // Start is called before the first frame update

    private void Awake()
    {
        rt = gameObject.GetComponent<RectTransform>();
        startPos = rt.anchoredPosition.x;
        targetPos = 225;
    }
    private void OnEnable()
    {
        
        Debug.Log("Opening");
        LeanTween.cancelAll();
        LeanTween.moveX(rt, targetPos, 1f);
    }

    public void OnCLose()
    {
        Debug.Log("Closing");
        LeanTween.cancelAll();
        LeanTween.moveX(rt, startPos, 0.2f).setOnComplete(Disable);
    }

    private void Disable()
    {
        rt.anchoredPosition = new Vector2(startPos, rt.anchoredPosition.y);
        gameObject.SetActive(false);
    }
}
