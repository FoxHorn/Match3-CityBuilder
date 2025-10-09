using UnityEngine;
using UnityEngine.UI;

public class ButtonContinueView : ButtonView
{
    [SerializeField] private Button button;

    protected override void UpdateView()
    {
        if (Model is GameModel gameModel)
        {
            SetInteractable(gameModel.HasSavedGame);
        }
    }

    private void SetInteractable(bool interactable)
    {
        button.interactable = interactable;
    }
}