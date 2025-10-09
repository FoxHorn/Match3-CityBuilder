using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResetGameSystemDefault : IResetGameSystem
{
    private readonly IScoreCalculatingSystem _scoreCalculator;

    public ResetGameSystemDefault(IScoreCalculatingSystem scoreCalculator)
    {
        _scoreCalculator = scoreCalculator;
    }

    private BuildingType GetRandomBuildingType()
    {
        float rand = Random.Range(0, 100f);
        if (rand < 50f) return BuildingType.Level1;
        if (rand < 80f) return BuildingType.Level2;
        if (rand < 95f) return BuildingType.Level3;
        return BuildingType.Level4;
    }

    private Field GenerateInitialField()
    {
        Field field = new();
        var occupiedCells = GetRandomPositions();

        foreach (var (Row, Col) in occupiedCells)
        {
            field.Cells[Row, Col].building = GetRandomBuildingType();
        }

        return field;
    }

    private Deck GenerateInitialDeck()
    {
        Deck deck = new();
        for (int i = 0; i < 3; i++)
        {
            deck.Buildings.Add(new Building { TypeId = GetRandomBuildingType() });
        }
        return deck;
    }

    public Game ResetGame()
    {
        Field field = GenerateInitialField();
        Deck deck = GenerateInitialDeck();
        int score = _scoreCalculator.CalculateTotalScore(field);

        return new Game
        {
            Field = field,
            CurrentDeck = deck,
            Score = score,
            JockerPoints = 3
        };
    }

    private IEnumerable<(int Row, int Col)> GetRandomPositions()
    {
        var positions = new List<(int Row, int Col)>(25);
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                positions.Add((row, col));
            }
        }

        //shuffle
        for (int i = 0; i < positions.Count; i++)
        {
            int j = Random.Range(i, positions.Count);
            (positions[i], positions[j]) = (positions[j], positions[i]);
        }

        return positions.Take(8);
    }
}
