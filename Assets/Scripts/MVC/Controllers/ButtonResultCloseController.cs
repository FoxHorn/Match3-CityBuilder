public class ButtonResultCloseController : ButtonController
{
    private ResultsController _resultsController;
    public void LazyInit(ResultsController resultsController)
    {
        _resultsController = resultsController;
    }

    public override void ButtonInput()
    {
        _resultsController.ClosePanel();
    }
}
