public class ButtonNewGameConroller : ButtonController
{
    private FiniteStateMachine _fsm;
    private MenuController _menuController;
    private SaveSystemController _saveSystemController;

    public void LazyInit(FiniteStateMachine fsm, MenuController menuController, SaveSystemController saveSystemController)
    {
        _fsm = fsm;
        _menuController = menuController;
        _saveSystemController = saveSystemController;
    }

    public override void ButtonInput()
    {
        InputManager.Instance.ToggleInput(false);
        _saveSystemController.ResetGameModel();
        _menuController.PerformHide(() => _fsm.SetState<StateGameAreaSetup>());
    }
}
