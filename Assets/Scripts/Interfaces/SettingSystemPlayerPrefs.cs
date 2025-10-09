using UnityEngine;

public class SettingSystemPlayerPrefs : ISettingSystem
{
    private readonly string _key = "IsSoundEnabled";

    public bool GetSoundSetting()
    {
        return PlayerPrefs.GetString(_key, "true") == "true";
    }

    public void SetSoundSetting(bool value)
    {
        PlayerPrefs.SetString(_key, value ? "true" : "false");
    }
}
