using UnityEngine;
using System;
using System.Collections;

public class GameAreaView : View
{
    [SerializeField] private GameObject gameAreaGameObject;
    [SerializeField] private Animator animator;

    private Action _onFinish;

    public void Show(Action onFinish)
    {
        _onFinish = onFinish;
        gameAreaGameObject.SetActive(true);
        animator.SetTrigger("Show");
        StartCoroutine(WaitOneDeltaTime(() => MonitorAnimationCompletion()));
    }

    public void Hide(Action onFinish)
    {
        _onFinish = onFinish;
        gameAreaGameObject.SetActive(false);
        animator.SetTrigger("Hide");
        StartCoroutine(WaitOneDeltaTime(() => MonitorAnimationCompletion()));
    }

    private void MonitorAnimationCompletion()
    {
        float waitTime = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        Invoke(nameof(CallCallback), waitTime);
    }

    private void CallCallback()
    {
        _onFinish?.Invoke();
        _onFinish = null;
    }

    private IEnumerator WaitOneDeltaTime(Action onFinish)
    {
        yield return null;
        onFinish?.Invoke();
    }
}