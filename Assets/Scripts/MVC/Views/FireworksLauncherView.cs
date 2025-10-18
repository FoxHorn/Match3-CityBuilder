using UnityEngine;
using System.Collections;

public class FireworksLauncherView : View
{
    [SerializeField] private float fireworkAnimMinTime, fireworkAnimMaxTime;
    [SerializeField] private Transform fireworksParent;
    [SerializeField] private GameObject fireworksPrefab;
    [SerializeField] private Vector3 launchPosition;
    [SerializeField] private Color[] colors;

    private IFireworksPool _fireworksPool;

    private void Awake()
    {
        _fireworksPool = new FireworksPoolDefault(fireworksPrefab, fireworksParent, 3);
    }

    public void StartLaunches()
    {
        StopAllCoroutines();
        StartCoroutine(LaunchPeriodicallyCoroutine());
    }

    public void StopLaunches()
    {
        StopAllCoroutines();
    }

    private void LaunchFirework()
    {
        FireworkView firework = _fireworksPool.GetFirework(colors[Random.Range(0, colors.Length)]);
        firework.PlayAt(launchPosition);
    }

    private IEnumerator LaunchPeriodicallyCoroutine()
    {
        while (true)
        {
            float randomDelay = Random.Range(fireworkAnimMinTime, fireworkAnimMaxTime);
            yield return new WaitForSeconds(randomDelay);
            LaunchFirework();
            float rand = Random.Range(0, 100f);
            if (rand > 90f)
            {
                yield return new WaitForSeconds(0.25f);
                LaunchFirework();
            }
        }
    }
}