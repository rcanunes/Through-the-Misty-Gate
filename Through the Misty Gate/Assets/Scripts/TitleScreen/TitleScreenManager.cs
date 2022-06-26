using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour {
    private Animator animator;

    [SerializeField] private List<Animator> buttonAnimators;

    void Start() {
        animator = GetComponent<Animator>();
        StartCoroutine(WaitForFadeIn());
    }

    private IEnumerator WaitForFadeIn() {
        SetButtonAnimators(false);

        yield return new WaitForSeconds(2);

        SetButtonAnimators(true);
    }

    public void FadeOut() {
        animator.SetBool("FadeOut", true);
    }

    private void SetButtonAnimators(bool value) {
        foreach (var buttonAnimator in buttonAnimators) {
            buttonAnimator.enabled = value;
        }
    }
}
