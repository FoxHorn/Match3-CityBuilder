using UnityEngine;
using TMPro;

public class ButtonSoundView : ButtonView
{
    [SerializeField] private TextMeshProUGUI buttonText;

    protected override void UpdateView()
    {
        if (Model is SettingsModel settingsModel)
        {
            buttonText.text = settingsModel.IsSoundEnabled ? "SOUND\nON" : "SOUND\nOFF";
        }
    }
}
