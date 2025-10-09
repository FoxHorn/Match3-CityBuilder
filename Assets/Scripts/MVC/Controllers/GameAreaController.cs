using System;

public class GameAreaController
{
    private readonly GameAreaView _view;

    public GameAreaController(GameAreaView view)
    {
        _view = view;
    }

    public void ShowArea(Action onAnimationComplete)
    {
        _view.Show(onAnimationComplete);
    }

    public void HideArea(Action onAnimationComplete)
    {
        _view.Hide(onAnimationComplete);
    }
}
