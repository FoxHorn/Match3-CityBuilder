using System.Collections.Generic;

public class JockerCalculatorSystemDefault : IJockerCalculatorSystem
{
    private readonly Dictionary<BuildingType, int> _priceTable = new()
    {
        { BuildingType.Level1, 1 },
        { BuildingType.Level2, 1 },
        { BuildingType.Level3, 1 },
        { BuildingType.Level4, 2 },
        { BuildingType.Level5, 4 },
        { BuildingType.Level6, 6 }
    };

    public int GetPriceForBuildingType(BuildingType type)
    {
        return _priceTable.TryGetValue(type, out int price) ? price : 0;
    }
}
