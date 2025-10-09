public class ButtonContinueController : ButtonController
{
    private FiniteStateMachine _fsm;
    private MenuController _menuController;

    public void LazyInit(FiniteStateMachine fsm, MenuController menuController)
    {
        _fsm = fsm;
        _menuController = menuController;
    }

    public override void ButtonInput()
    {
        InputManager.Instance.ToggleInput(false);
        _menuController.PerformHide(() => _fsm.SetState<StateGameAreaSetup>());
    }
}
