public class TutorialController
{
    private readonly TutorialView _tutorialView;
    private readonly TutorialModel _tutorialModel;

    public TutorialController (TutorialView tutorialView, TutorialModel tutorialModel)
    {
        _tutorialView = tutorialView;
        _tutorialModel = tutorialModel;
        _tutorialModel.TotalPages = _tutorialView.PagesLength;
    }

    public void OpenTutorial()
    {
        InputManager.Instance.ToggleInput(false);
        _tutorialView.Show(() => InputManager.Instance.ToggleInput(true));
        _tutorialModel.CurrentPage = 0;
    }

    public void CloseTutorial()
    {
        InputManager.Instance.ToggleInput(false);
        _tutorialView.Hide(() => InputManager.Instance.ToggleInput(true));
    }

    public void Next()
    {
        if (_tutorialModel.CurrentPage + 1 < _tutorialModel.TotalPages) _tutorialModel.CurrentPage++;
        else _tutorialModel.CurrentPage = 0;
    }

    public void Previous()
    {
        if (_tutorialModel.CurrentPage > 0) _tutorialModel.CurrentPage--;
        else _tutorialModel.CurrentPage = _tutorialModel.TotalPages - 1;
    }
}
