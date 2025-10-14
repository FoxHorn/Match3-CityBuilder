public class ButtonTutorialPreviousController : ButtonController
{
    private TutorialController _tutorialConroller;

    public void LazyInit(TutorialController tutorialConroller)
    {
        _tutorialConroller = tutorialConroller;
    }

    public override void ButtonInput()
    {
        _tutorialConroller.Previous();
    }
}
