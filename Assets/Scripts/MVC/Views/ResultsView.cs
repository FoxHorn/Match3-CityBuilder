using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class ResultsView : View
{
    [SerializeField] private GameObject jockerPanelGameObject;
    [SerializeField] private CanvasGroup group;
    [SerializeField] private TextMeshProUGUI scoreText;
    [Space(10)]
    [SerializeField] private float animTime;
    [SerializeField] private FireworksLauncherView fireworksLaucher;

    public void Show(Action onAnimationComplete)
    {
        fireworksLaucher.StartLaunches();
        if (Model is GameModel gameModel)
        {
            scoreText.text = gameModel.CurrentGame.Score.ToString();
        }
        StartCoroutine(ShowAnim(onAnimationComplete));
    }

    public void Hide(Action onAnimationComplete)
    {
        fireworksLaucher.StopLaunches();
        StartCoroutine(HideAnim(onAnimationComplete));
    }

    private IEnumerator ShowAnim(Action onAnimationComplete)
    {
        jockerPanelGameObject.SetActive(true);
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
        jockerPanelGameObject.SetActive(false);
        onAnimationComplete?.Invoke();
    }
}
