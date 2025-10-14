public class ButtonTutorialNextController : ButtonController
{
    private TutorialController _tutorialConroller;

    public void LazyInit(TutorialController tutorialConroller)
    {
        _tutorialConroller = tutorialConroller;
    }

    public override void ButtonInput()
    {
        _tutorialConroller.Next();
    }
}
