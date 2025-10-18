public class ButtonJokerBuildingController : ButtonController
{
    private JokerButtonsPanelController _panelController;
    private ButtonInteractableView _view;

    private BuildingType _type;

    public void SetupButton(BuildingType type, bool interactable)
    {
        _type = type;
        _view.SetInteractable(interactable);
    }

    public void LazyInit(JokerButtonsPanelController panelController, ButtonInteractableView view)
    {
        _panelController = panelController;
        _view = view;
    }

    public override void ButtonInput()
    {
        _panelController.SwitchFirstDeckItem(_type);
    }
}
