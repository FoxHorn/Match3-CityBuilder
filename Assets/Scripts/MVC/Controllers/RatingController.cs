public class RatingController
{
    private readonly RatingModel _model;
    private readonly IRatingSystem _ratingGetter;

    public RatingController(RatingModel model, IRatingSystem ratingGetter)
    {
        _model = model;
        _ratingGetter = ratingGetter;
    }

    public void GetRating()
    {
        _model.CurRating = _ratingGetter.GetRating();
    }
}
