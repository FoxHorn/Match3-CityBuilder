using UnityEngine;

public class SettingSystemTest : ISettingSystem
{
    public bool GetSoundSetting()
    {
        return true;
    }

    public void SetSoundSetting(bool value)
    {
        Debug.Log($"Set Sound Setting: {value}");
    }
}
