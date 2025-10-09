using UnityEngine;

public class StateMenu : State
{
    private readonly MenuController _menu;
    private readonly SaveSystemController _saveSystem;
    private readonly RatingController _rating;
    private readonly SettingsController _settings;

    public StateMenu(FiniteStateMachine fsm, MenuController menu, SaveSystemController saveSystem, RatingController rating, SettingsController settings) : base(fsm)
    {
        _menu = menu;
        _saveSystem = saveSystem;
        _rating = rating;
        _settings = settings;
    }

    public override void Enter()
    {
        Debug.Log("Menu state [ENTER]");
        _menu.PerformShow(() =>{
            _saveSystem.LoadSaveGame();
            _rating.GetRating();
            _settings.GetSetting();
            InputManager.Instance.ToggleInput(true);
        });
    }

    public override void Exit()
    {
        Debug.Log("Menu state [EXIT]");
    }

    public override void Update()
    {
        Debug.Log("Menu state [UPDATE]");
    }
}
