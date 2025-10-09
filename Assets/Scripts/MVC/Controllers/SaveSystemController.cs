public class SaveSystemController
{
    private readonly GameModel _model;
    private readonly ISaveSystem _saveSystem;
    private readonly IResetGameSystem _resetGameSystem;

    public SaveSystemController(GameModel model, ISaveSystem saveSystem, IResetGameSystem resetGameSystem)
    {
        _model = model;
        _saveSystem = saveSystem;
        _resetGameSystem = resetGameSystem;
    }

    public void LoadSaveGame()
    {
        _model.CurrentGame = _saveSystem.Load();
    }

    public void ResetGameModel()
    {
        _model.CurrentGame = _resetGameSystem.ResetGame();
    }
}
