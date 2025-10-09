public class ButtonView : View
{
    private protected ButtonController _controller;

    public virtual void LazyInit(ButtonController controller)
    {
        _controller = controller;
    }

    public virtual void ClickAction()
    {
        SoundManager.Instance.PlaySound(SoundManager.Sound.Click);
        _controller.ButtonInput();
    }
}
