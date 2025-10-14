public class TutorialModel : Model
{
    private int totalPages;
    public int TotalPages
    {
        get { return totalPages; }
        set { totalPages = value; }
    }

    private int currentPage;
    public int CurrentPage
    {
        get => currentPage;
        set
        {
            currentPage = value;
            NotifyObservers();
        }
    }
}
