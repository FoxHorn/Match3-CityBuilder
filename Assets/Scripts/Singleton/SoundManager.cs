using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource m_AudioSource;
    [Space(10)]
    [SerializeField] private AudioClip m_ClickClip;
    [SerializeField] private AudioClip m_PopClip;
    [SerializeField] private AudioClip m_PlaceClip;
    [SerializeField] private AudioClip m_FireworksClip;

    public enum Sound
    {
        Click,
        Pop,
        Place,
        Fireworks
    }

    private SettingsModel m_SettingsModel;

    public void Init(SettingsModel settingsModel)
    {
        m_SettingsModel = settingsModel;
    }

    public void PlaySound(Sound sound, bool randomPitch = false)
    {
        if (m_SettingsModel != null && m_SettingsModel.IsSoundEnabled)
        {
            AudioClip clip = sound switch
            {
                Sound.Click => m_ClickClip,
                Sound.Pop => m_PopClip,
                Sound.Place => m_PlaceClip,
                Sound.Fireworks => m_FireworksClip,
                _ => null
            };
            m_AudioSource.clip = clip;
            m_AudioSource.pitch = randomPitch ? Random.Range(-0.75f, 1.25f) : 1;
            m_AudioSource.Play();
        }
    }
}
