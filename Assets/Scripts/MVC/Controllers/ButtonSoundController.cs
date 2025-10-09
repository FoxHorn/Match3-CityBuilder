public class ButtonSoundController : ButtonController
{
    private SettingsController _settingsController;

    public void LazyInit(SettingsController settingController)
    {
        _settingsController = settingController;
    }

    public override void ButtonInput()
    {
        _settingsController.SetSetting();
    }
}