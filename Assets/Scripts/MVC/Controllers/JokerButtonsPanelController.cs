using System;
using System.Collections.Generic;

public class JokerButtonsPanelController
{
    private readonly IJokerCalculatorSystem _jokerCalculatorSystem;
    private readonly GameModel _gameModel;

    private JokerController _controller;
    private List<ButtonJokerBuildingController> _buttons;

    public JokerButtonsPanelController(GameModel gameModel, IJokerCalculatorSystem jokerCalculatorSystem)
    {
        _gameModel = gameModel;
        _jokerCalculatorSystem = jokerCalculatorSystem;
    }

    public void LazyInit(List<ButtonJokerBuildingController> buttons, JokerController controller)
    {
        _buttons = buttons;
        _controller = controller;
    }

    public void SwitchFirstDeckItem(BuildingType type)
    {
        int price = _jokerCalculatorSystem.GetPriceForBuildingType(type);
        if (price > 0 && price <= _gameModel.CurrentGame.JokerPoints)
        {
            _gameModel.CurrentGame.JokerPoints -= price;
            _gameModel.CurrentGame.CurrentDeck.Buildings[^1].TypeId = type;
        }
        _controller.ClosePanel();
    }

    public void SetupButtons()
    {
        Array jokerBuildingsArray = Enum.GetValues(typeof(BuildingType));
        for (int i = 0; i < _buttons.Count; i++)
        {
            BuildingType type = (BuildingType)jokerBuildingsArray.GetValue(i + 1);
            int price = _jokerCalculatorSystem.GetPriceForBuildingType(type);
            bool interactable = _gameModel.CurrentGame.JokerPoints >= price;
            _buttons[i].SetupButton(type, interactable);
        }
    }
}