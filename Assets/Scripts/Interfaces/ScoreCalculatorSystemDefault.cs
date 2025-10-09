using System.Collections.Generic;

public class ScoreCalculatorSystemDefault : IScoreCalculatingSystem
{
    private readonly Dictionary<BuildingType, int> _scoreTable = new()
    {
        { BuildingType.Level1, 4 },
        { BuildingType.Level2, 8 },
        { BuildingType.Level3, 16 },
        { BuildingType.Level4, 32 },
        { BuildingType.Level5, 64 },
        { BuildingType.Level6, 128 },
        { BuildingType.Level7, 256 },
        { BuildingType.Level8, 512 }
    };

    public int CalculateTotalScore(Field field)
    {
        int totalScore = 0;
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                totalScore += GetScoreForBuildingType(field.Cells[row, col].building);
            }
        }
        return totalScore;
    }

    public int GetScoreForBuildingType(BuildingType type)
    {
        return _scoreTable.TryGetValue(type, out int score) ? score : 0;
    }
}
