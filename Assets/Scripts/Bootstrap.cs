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
    [SerializeField] private TutorialView _tutorialView;
    [SerializeField] private ButtonView _buttonTutorialNextView;
    [SerializeField] private ButtonView _buttonTutorialPreviousView;
    [SerializeField] private ButtonView _buttonTutorialCloseView;
    [SerializeField] private JockerView _jockerView;
    [SerializeField] private ButtonView _buttonJockerCancelView;
    [SerializeField] private ButtonJockerBuildingView[] _buttonJockerBuildingViews;

    private GameModel _gameModel;
    private RatingModel _ratingModel;
    private SettingsModel _settingsModel;
    private TutorialModel _tutorialModel;

    private SettingsController _settingsController;
    private SaveSystemController _saveSystemController;
    private MenuController _menuController;
    private RatingController _ratingController;
    private ButtonContinueController _buttonContinueController;
    private ButtonSoundController _buttonSoundController;
    private ButtonNewGameConroller _buttonNewGameController;
    private GameAreaController _gameAreaController;
    private TutorialController _tutorialController;
    private ButtonTutorialNextController _buttonTutorialNextConroller;
    private ButtonTutorialPreviousController _buttonTutorialPreviousConroller;
    private ButtonTutorialCloseController _buttonTutorialCloseController;
    private JockerController _jockerController;
    private ButtonJockerCancelController _buttonJockerCancelController;

    private FiniteStateMachine _fsm;

    private void Awake()
    {
        //Set models
        _gameModel = new GameModel();
        _ratingModel = new RatingModel();
        _settingsModel = new SettingsModel();
        _tutorialModel = new TutorialModel();

        //Set views
        _ratingView.Init(_ratingModel);
        _buttonContinueView.Init(_gameModel);
        _buttonSoundView.Init(_settingsModel);
        _buttonNewGameView.Init();
        _gameAreaView.Init();
        _tutorialView.Init(_tutorialModel);
        _jockerView.Init(_gameModel);

        //Set controllers
        _settingsController = new SettingsController(_settingsModel, new SettingSystemPlayerPrefs());
        _saveSystemController = new SaveSystemController(_gameModel, new SaveSystemBinary(), new ResetGameSystemDefault(new ScoreCalculatorSystemDefault()));
        _menuController = new MenuController(_menuView);
        _ratingController = new RatingController(_ratingModel, new RatingSystemLocal());
        _buttonContinueController = new ButtonContinueController();
        _buttonSoundController = new ButtonSoundController();
        _buttonNewGameController = new ButtonNewGameConroller();
        _gameAreaController = new GameAreaController(_gameAreaView);
        _tutorialController = new TutorialController(_tutorialView, _tutorialModel);
        _buttonTutorialNextConroller = new ButtonTutorialNextController();
        _buttonTutorialPreviousConroller = new ButtonTutorialPreviousController();
        _buttonTutorialCloseController = new ButtonTutorialCloseController();
        _jockerController = new JockerController(_jockerView, _gameModel, new JockerCalculatorSystemDefault());

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
        _buttonTutorialNextConroller.LazyInit(_tutorialController);
        _buttonTutorialPreviousConroller.LazyInit(_tutorialController);
        _buttonTutorialCloseController.LazyInit(_tutorialController);
        _buttonJockerCancelController.LazyInit(_jockerController);
        _buttonTutorialNextView.LazyInit(_buttonTutorialNextConroller);
        _buttonTutorialPreviousView.LazyInit(_buttonTutorialPreviousConroller);
        _buttonTutorialCloseView.LazyInit(_buttonTutorialCloseController);
        _buttonJockerCancelView.LazyInit(_buttonJockerCancelController);
        foreach(var buttonJockerBuildingView in _buttonJockerBuildingViews)
        {
            buttonJockerBuildingView.LazyInit(new JockerCalculatorSystemDefault());
        }

        //Start fsm
        _fsm.SetState<StateMenu>();
        _fsmUpdater.Init(_fsm);
    }
}
