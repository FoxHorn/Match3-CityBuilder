using System;
using System.Collections;
using UnityEngine;

public class JokerView : View
{
    [SerializeField] private GameObject jokerPanelGameObject;
    [SerializeField] private CanvasGroup group;
    [Space(10)]
    [SerializeField] private float animTime;

    public override void ResetView()
    {
        StopAllCoroutines();
        group.alpha = 0;
        jokerPanelGameObject.SetActive(false);
    }

    public void Show(Action onAnimationComplete)
    {
        StartCoroutine(ShowAnim(onAnimationComplete));
    }

    public void Hide(Action onAnimationComplete)
    {
        StartCoroutine(HideAnim(onAnimationComplete));
    }

    private IEnumerator ShowAnim(Action onAnimationComplete)
    {
        jokerPanelGameObject.SetActive(true);
        float animTime = this.animTime;
        while (animTime > 0)
        {
            group.alpha = 1 - animTime / this.animTime;
            animTime -= Time.deltaTime;
            yield return null;
        }
        group.alpha = 1;
        onAnimationComplete?.Invoke();
    }

    private IEnumerator HideAnim(Action onAnimationComplete)
    {
        float animTime = this.animTime;
        while (animTime > 0)
        {
            group.alpha = animTime / this.animTime;
            animTime -= Time.deltaTime;
            yield return null;
        }
        ResetView();
        onAnimationComplete?.Invoke();
    }
}
