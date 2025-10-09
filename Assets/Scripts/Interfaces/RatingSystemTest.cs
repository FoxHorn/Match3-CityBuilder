using UnityEngine;

public class RatingSystemTest : IRatingSystem
{
    private readonly Rating _testRatingValue = new() { BiggestCity = 10345, Rank = 201 };

    public Rating GetRating()
    {
        return _testRatingValue;
    }

    public void SubmitRecord(int score)
    {
        Debug.Log($"Submit score: {score}");
    }
}
