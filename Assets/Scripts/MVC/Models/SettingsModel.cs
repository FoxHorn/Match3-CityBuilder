public class SettingsModel : Model
{
    private bool isSoundEnabled;

    public bool IsSoundEnabled
    {
        get => isSoundEnabled;
        set
        {
            isSoundEnabled = value;
            NotifyObservers();
        }
    }
}
