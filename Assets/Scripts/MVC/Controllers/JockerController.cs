public class JockerController
{
    private readonly JockerView _jockerView;
    private readonly GameModel _gameModel;
    private readonly IJockerCalculatorSystem _calculatorSystem;

    public JockerController(JockerView jockerView, GameModel gameModel, IJockerCalculatorSystem calculatorSystem)
    {
        _jockerView = jockerView;
        _gameModel = gameModel;
        _calculatorSystem = calculatorSystem;
    }

    public void SwitchDeckItem(BuildingType type)
    {
        int price = _calculatorSystem.GetPriceForBuildingType(type);
        if (price > 0 || price <= _gameModel.CurrentGame.JockerPoints)
        {
            _gameModel.CurrentGame.JockerPoints -= price;
            _gameModel.CurrentGame.CurrentDeck.Buildings[^1].TypeId = type;
        }
    }

    public void OpenPanel()
    {
        InputManager.Instance.ToggleInput(false);
        _jockerView.ResetView();
        _jockerView.Show(() => InputManager.Instance.ToggleInput(true));
    }

    public void ClosePanel()
    {
        InputManager.Instance.ToggleInput(false);
        _jockerView.Hide(() => InputManager.Instance.ToggleInput(true));
    }
}
