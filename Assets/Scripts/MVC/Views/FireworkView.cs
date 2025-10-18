using System.Collections;
using UnityEngine;

public class FireworkView : MonoBehaviour
{
    public ParticleSystem particles;
    public ParticleSystem subEmittor;
    public IFireworksPool Pool;

    public void SetColor(Color color)
    {
        var main = particles.main;
        main.startColor = new ParticleSystem.MinMaxGradient(color);
    }

    public void PlayAt(Vector3 position)
    {
        transform.localPosition = position;
        particles.Play();
        StartCoroutine(OnSubEmmiterPlay());
    }

    private void OnParticleSystemStopped()
    {
        Pool?.ReturnFirework(this);
    }

    private IEnumerator OnSubEmmiterPlay()
    {
        bool hasPlayedSound = false;
        while (!hasPlayedSound)
        {
            if (subEmittor.isPlaying)
            {
                SoundManager.Instance.PlaySound(SoundManager.Sound.Fireworks, true);
                hasPlayedSound = true;
            }
            yield return null;
        }
    }
}