public class ButtonJockerCancelController : ButtonController
{
    private JockerController _jockerConroller;

    public void LazyInit(JockerController jockerConroller)
    {
        _jockerConroller = jockerConroller;
    }

    public override void ButtonInput()
    {
        _jockerConroller.ClosePanel();
    }
}
