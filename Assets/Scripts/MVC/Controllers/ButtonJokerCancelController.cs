public class ButtonJokerCancelController : ButtonController
{
    private JokerController _jokerConroller;

    public void LazyInit(JokerController jockerConroller)
    {
        _jokerConroller = jockerConroller;
    }

    public override void ButtonInput()
    {
        _jokerConroller.ClosePanel();
    }
}
