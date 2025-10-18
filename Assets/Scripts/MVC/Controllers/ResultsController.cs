public class ResultsController
{
    private readonly ResultsView _resultsView;

    public ResultsController(ResultsView resultsView)
    {
        _resultsView = resultsView;
    }

    public void OpenPanel()
    {
        InputManager.Instance.ToggleInput(false);
        _resultsView.Show(() => InputManager.Instance.ToggleInput(true));
    }

    public void ClosePanel()
    {
        InputManager.Instance.ToggleInput(false);
        _resultsView.Hide(() => InputManager.Instance.ToggleInput(true));
    }
}
