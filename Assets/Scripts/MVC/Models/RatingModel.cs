public class Rating
{
    public int BiggestCity { get; set; }
    public int Rank { get; set; }
}

public class RatingModel : Model
{
    private Rating curRating;

    public Rating CurRating
    {
        get => curRating;
        set
        {
            curRating = value;
            NotifyObservers();
        }
    }
}