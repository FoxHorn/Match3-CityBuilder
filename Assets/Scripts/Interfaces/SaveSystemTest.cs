using System.Collections.Generic;
using UnityEngine;

public class SaveSystemTest : ISaveSystem
{
    private readonly IScoreCalculatingSystem _scoreCalculatingSystem;

    public SaveSystemTest(IScoreCalculatingSystem scoreCalculatingSystem)
    {
        _scoreCalculatingSystem = scoreCalculatingSystem;
    }

    public Game Load()
    {
        Field field = CreateSampleField();
        Deck deck = CreateSampleDeñk();

        Game game = new()
        {
            CurrentDeck = deck,
            Field = field,
            Score = _scoreCalculatingSystem.CalculateTotalScore(field),
            JokerPoints = 3
        };

        return game;
    }

    public void Save(Game game)
    {
        Debug.Log("SaveSystemTest game saved");
    }

    private Deck CreateSampleDeñk()
    {
        Deck deck = new();

        for (int i = 0; i < deck.Buildings.Count; i++)
        {
            BuildingType buildingType = Random.Range(0, 4) switch
            {
                0 => BuildingType.Level1,
                1 => BuildingType.Level2,
                2 => BuildingType.Level3,
                3 => BuildingType.Level4,
                _ => BuildingType.None,
            };

            deck.Buildings[i].TypeId = buildingType;
        }
        return deck;
    }

    private Field CreateSampleField()
    {
        Field field = new()
        {
            Cells = new FieldCell[5, 5]
        };

        for (int i = 0; i < field.Cells.GetLength(0); i++)
        {
            for (int j = 0; j < field.Cells.GetLength(1); j++)
            {
                field.Cells[i, j].building = BuildingType.None;
            }
        }

        List<BuildingType> buildings = new()
        {
        BuildingType.Level1,
        BuildingType.Level1,
        BuildingType.Level1,
        BuildingType.Level2,
        BuildingType.Level2,
        BuildingType.Level3,
        BuildingType.Level3,
        BuildingType.Level4,
        };

        List<Vector2Int> coords = new();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                coords.Add(new Vector2Int(i, j));
            }
        }

        while (buildings.Count > 0)
        {
            int index = Random.Range(0, buildings.Count);
            BuildingType buildingType = buildings[index];
            buildings[index] = buildings[^1];
            buildings.RemoveAt(buildings.Count - 1);

            int index2 = Random.Range(0, coords.Count);
            Vector2Int coord = coords[index2];
            coords[index2] = coords[^1];
            coords.RemoveAt(coords.Count - 1);

            field.Cells[coord.x, coord.y].building = buildingType;
        }

        return field;
    }
}
