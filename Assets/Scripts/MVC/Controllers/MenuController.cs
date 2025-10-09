using System;
using UnityEngine.EventSystems;

public class MenuController
{
    private readonly MenuView _menuView;

    public MenuController(MenuView menuView)
    {
        _menuView = menuView;
    }

    public void PerformShow(Action onAnimationComplete)
    {
        _menuView.ResetView();
        _menuView.Show(onAnimationComplete);
    }

    public void PerformHide(Action onAnimationComplete)
    {
        EventSystem.current.enabled = false;
        _menuView.Hide(onAnimationComplete);
    }
}
