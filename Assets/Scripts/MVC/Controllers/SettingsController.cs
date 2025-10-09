public class SettingsController
{
    private readonly SettingsModel _model;
    private readonly ISettingSystem _settingSystem;

    public SettingsController(SettingsModel model, ISettingSystem settingSystem)
    {
        _model = model;
        _settingSystem = settingSystem;
    }

    public void GetSetting()
    {
        UpdateModel();
    }

    public void SetSetting()
    {
        _settingSystem.SetSoundSetting(!_model.IsSoundEnabled);
        UpdateModel();
    }

    private void UpdateModel()
    {
        _model.IsSoundEnabled = _settingSystem.GetSoundSetting();
    }
}