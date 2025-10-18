using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractableView : ButtonView
{
    [SerializeField] private Button button;

    protected override void UpdateView()
    {
        if (Model is GameModel gameModel)
        {
            SetInteractable(gameModel.HasSavedGame);
        }
    }

    public void SetInteractable(bool interactable)
    {
        button.interactable = interactable;
    }
}