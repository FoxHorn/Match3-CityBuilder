using System.Collections.Generic;
using UnityEngine;

public class FireworksPoolDefault : IFireworksPool
{
    private readonly Queue<FireworkView> _fireworksQueue;
    private readonly GameObject _prefab;
    private readonly Transform _containerTransform;

    public FireworksPoolDefault(GameObject prefab, Transform containerTransform, int initialCount)
    {
        _prefab = prefab;
        _containerTransform = containerTransform;
        _fireworksQueue = new Queue<FireworkView>();

        for (int i = 0; i < initialCount; i++)
        {
            EnqueueNewFirework();
        }
    }

    private void EnqueueNewFirework()
    {
        GameObject go = Object.Instantiate(_prefab, _containerTransform);
        FireworkView view = go.GetComponent<FireworkView>();
        view.Pool = this;
        view.gameObject.SetActive(false);
        _fireworksQueue.Enqueue(view);
    }

    public FireworkView GetFirework(Color color)
    {
        FireworkView firework;

        if (_fireworksQueue.Count == 0)
        {
            EnqueueNewFirework();
        }

        firework = _fireworksQueue.Dequeue();
        firework.SetColor(color);
        firework.gameObject.SetActive(true);
        return firework;
    }

    public void ReturnFirework(FireworkView firework)
    {
        firework.gameObject.SetActive(false);
        _fireworksQueue.Enqueue(firework);
    }
}
