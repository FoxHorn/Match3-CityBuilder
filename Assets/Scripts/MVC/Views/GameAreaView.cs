using UnityEngine;
using System;

public class GameAreaView : View
{
    [SerializeField] private Animator animator;

    private Action _onFinish;

    public void Show(Action onFinish)
    {
        animator.SetTrigger("Show");
        MonitorAnimationCompletion(onFinish);
    }

    public void Hide(Action onFinish)
    {
        animator.SetTrigger("Hide");
        MonitorAnimationCompletion(onFinish);
    }

    private void MonitorAnimationCompletion(Action onFinish)
    {
        _onFinish = onFinish;
        float waitTime = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        Invoke(nameof(CallCallback), waitTime);
    }

    private void CallCallback()
    {
        _onFinish?.Invoke();
        _onFinish = null;
    }
}