public class FieldController
{
    private readonly FieldView _fieldView;
    private readonly GameModel _gameModel;

    public FieldController(FieldView fieldView, GameModel gameModel)
    {
        _fieldView = fieldView;
        _gameModel = gameModel;
    }
}
