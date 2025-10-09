using UnityEngine;
using TMPro;
using System.Collections;

public class RatingView : View
{
    [SerializeField] private CanvasGroup upGroup, downGroup;
    [SerializeField] private TMP_Text biggestText, rankText;
    [SerializeField] private RectTransform[] upLines, downLines;
    [Space(10)]
    [SerializeField] private float showAnimTime;

    public override void ResetView()
    {
        StopAllCoroutines();

        ResetLines(upLines);
        ResetLines(downLines);
        ResetGroup(upGroup);
        ResetGroup(downGroup);
    }

    protected override void UpdateView()
    {
        if (Model is RatingModel ratingModel)
        {
            if (ratingModel.CurRating != null)
            {
                biggestText.text = ratingModel.CurRating.BiggestCity.ToString();
                rankText.text = "#" + ratingModel.CurRating.Rank.ToString();

                StartCoroutine(LinesAnim(downLines));
                StartCoroutine(ShowAnim(downGroup));
            }
            StartCoroutine(LinesAnim(upLines));
            StartCoroutine(ShowAnim(upGroup));
        }
    }

    private void ResetLines(RectTransform[] lines)
    {
        foreach (var line in lines)
        {
            line.localScale = new Vector3(0, 1, 1);
        }
    }

    private void ResetGroup(CanvasGroup group)
    {
        group.alpha = 0;
    }

    private IEnumerator LinesAnim(RectTransform[] lines)
    {
        float animTime = showAnimTime;
        while (animTime > 0)
        {
            foreach (var line in lines)
            {
                line.localScale = Vector3.Lerp(new Vector3(0, 1, 1), Vector3.one, 1 - animTime / showAnimTime);
            }
            animTime -= Time.deltaTime;
            yield return null;
        }
        foreach (var line in lines)
        {
            line.localScale = Vector3.one;
        }
    }

    private IEnumerator ShowAnim(CanvasGroup group)
    {
        float animTime = showAnimTime;
        while (animTime > 0)
        {
            group.alpha = 1 - animTime / showAnimTime;
            animTime -= Time.deltaTime;
            yield return null;
        }
        group.alpha = 1;
    }
}