using System.Collections.Generic;

public enum BuildingType
{
    None,
    Level1,
    Level2,
    Level3,
    Level4,
    Level5,
    Level6,
    Level7,
    Level8
}

public struct FieldCell
{
    public BuildingType building;
}

public class Building
{
    public BuildingType TypeId;
}

public class Field
{
    public FieldCell[,] Cells = new FieldCell[5, 5];
}

public class Deck
{
    public List<Building> Buildings = new(3);
}

public class Game
{
    public Field Field;
    public Deck CurrentDeck;
    public int Score;
    public int JokerPoints;
}

public class GameModel : Model
{
    private Game currentGame;

    public Game CurrentGame
    {
        get => currentGame;
        set
        {
            currentGame = value;
            NotifyObservers();
        }
    }

    public bool HasSavedGame
    {
        get => currentGame != null;
    }
}