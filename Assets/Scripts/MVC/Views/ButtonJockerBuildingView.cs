using UnityEngine;
using UnityEngine.UI;

public class ButtonJockerBuildingView : ButtonView
{
    [SerializeField] private Button button;
    [SerializeField] private BuildingType buildingType;

    private IJockerCalculatorSystem _jockerCalculatorSystem;

    public void LazyInit(IJockerCalculatorSystem jockerCalculatorSystem)
    {
        _jockerCalculatorSystem = jockerCalculatorSystem;
    }

    public void CheckInteractable()
    {
        if (Model is GameModel gameModel)
        {
            button.interactable = gameModel.CurrentGame.JockerPoints >= _jockerCalculatorSystem.GetPriceForBuildingType(buildingType);
        }
    }
}