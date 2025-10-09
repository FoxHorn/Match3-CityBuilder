using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private FSMUpdater _fsmUpdater;
    [Space(10)]
    [SerializeField] private MenuView _menuView;
    [SerializeField] private RatingView _ratingView;
    [SerializeField] private ButtonContinueView _buttonContinueView;
    [SerializeField] private ButtonSoundView _buttonSoundView;
    [SerializeField] private ButtonView _buttonNewGameView;
    [SerializeField] private GameAreaView _gameAreaView;

    private GameModel _gameModel;
    private RatingModel _ratingModel;
    private SettingsModel _settingsModel;

    private SettingsController _settingsController;
    private SaveSystemController _saveSystemController;
    private MenuController _menuController;
    private RatingController _ratingController;
    private ButtonContinueController _buttonContinueController;
    private ButtonSoundController _buttonSoundController;
    private ButtonNewGameConroller _buttonNewGameController;
    private GameAreaController _gameAreaController;

    private FiniteStateMachine _fsm;

    private void Awake()
    {
        //Set models
        _gameModel = new GameModel();
        _ratingModel = new RatingModel();
        _settingsModel = new SettingsModel();

        //Set views
        _ratingView.Init(_ratingModel);
        _buttonContinueView.Init(_gameModel);
        _buttonSoundView.Init(_settingsModel);
        _buttonNewGameView.Init();
        _gameAreaView.Init();

        //Set controllers
        _settingsController = new SettingsController(_settingsModel, new SettingSystemPlayerPrefs());
        _saveSystemController = new SaveSystemController(_gameModel, new SaveSystemBinary(), new ResetGameSystemDefault(new ScoreCalculatorSystemDefault()));
        _menuController = new MenuController(_menuView);
        _ratingController = new RatingController(_ratingModel, new RatingSystemLocal());
        _buttonContinueController = new ButtonContinueController();
        _buttonSoundController = new ButtonSoundController();
        _buttonNewGameController = new ButtonNewGameConroller();
        _gameAreaController = new GameAreaController(_gameAreaView);

        //Set managers
        SoundManager.Instance.Init(_settingsModel);

        //Set fsm
        _fsm = new FiniteStateMachine();
        _fsm.AddState(new StateMenu(_fsm, _menuController, _saveSystemController, _ratingController, _settingsController));
        _fsm.AddState(new StateGameAreaSetup(_fsm, _gameAreaController));

        //Lazy initialization
        _buttonContinueController.LazyInit(_fsm, _menuController);
        _buttonSoundController.LazyInit(_settingsController);
        _buttonNewGameController.LazyInit(_fsm, _menuController, _saveSystemController);
        _buttonContinueView.LazyInit(_buttonContinueController);
        _buttonSoundView.LazyInit(_buttonSoundController);
        _buttonNewGameView.LazyInit(_buttonNewGameController);

        //Start fsm
        _fsm.SetState<StateMenu>();
        _fsmUpdater.Init(_fsm);
    }
}
