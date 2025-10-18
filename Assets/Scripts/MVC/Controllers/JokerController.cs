public class JokerController
{
    private readonly JokerView _jokerView;
    private JokerButtonsPanelController _jokerButtonsPanelController;

    public JokerController(JokerView jokerView)
    {
        _jokerView = jokerView;
    }

    public void LazyInit(JokerButtonsPanelController jokerButtonsPanelController)
    {
        _jokerButtonsPanelController = jokerButtonsPanelController;
    }

    public void OpenPanel()
    {
        _jokerButtonsPanelController.SetupButtons();
        InputManager.Instance.ToggleInput(false);
        _jokerView.Show(() => InputManager.Instance.ToggleInput(true));
    }

    public void ClosePanel()
    {
        InputManager.Instance.ToggleInput(false);
        _jokerView.Hide(() => InputManager.Instance.ToggleInput(true));
    }
}
