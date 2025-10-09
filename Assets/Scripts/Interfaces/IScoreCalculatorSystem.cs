public interface IScoreCalculatingSystem
{
    int GetScoreForBuildingType(BuildingType type);
    int CalculateTotalScore(Field field);
}
