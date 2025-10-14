using System;
using UnityEngine;

public class MonoBehaviourStateNotifier : MonoBehaviour
{
    public event Action<bool> OnStateChanged;

    private void OnEnable()
    {
        Notify(true);
    }

    private void OnDisable()
    {
        Notify(false);
    }

    private void Notify(bool isEnabled)
    {
        OnStateChanged?.Invoke(isEnabled);
    }
}
