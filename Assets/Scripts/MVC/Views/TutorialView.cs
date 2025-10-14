using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct TutorialPage
{
    public Image dotImage;
    public GameObject pageObj;
}

public class TutorialView : View
{
    [SerializeField] private GameObject tutorialGameObject;
    [SerializeField] private CanvasGroup group;
    [SerializeField] private TutorialPage[] pages;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    [Space(10)]
    [SerializeField] private float animTime;

    private int activePage;

    public int PagesLength
    {
        get { return pages.Length; }
    }

    protected override void UpdateView()
    {
        ResetPage();
        if (Model is TutorialModel tutorialModel)
        {
            pages[tutorialModel.CurrentPage].dotImage.color = activeColor;
            pages[tutorialModel.CurrentPage].pageObj.SetActive(true);
            activePage = tutorialModel.CurrentPage;
        }
    }

    public override void ResetView()
    {
        pages[0].dotImage.color = activeColor;
        pages[0].pageObj.SetActive(true);
        StopAllCoroutines();
        group.alpha = 0;
    }

    public void Show(Action onAnimationComplete)
    {
        StartCoroutine(ShowAnim(onAnimationComplete));
    }

    public void Hide(Action onAnimationComplete)
    {
        StartCoroutine(HideAnim(onAnimationComplete));
    }

    private void ResetPage()
    {
        pages[activePage].dotImage.color = inactiveColor;
        pages[activePage].pageObj.SetActive(false);
    }

    private IEnumerator ShowAnim(Action onAnimationComplete)
    {
        tutorialGameObject.SetActive(true);
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
        group.alpha = 0;
        tutorialGameObject.SetActive(false);
        onAnimationComplete?.Invoke();
    }
}