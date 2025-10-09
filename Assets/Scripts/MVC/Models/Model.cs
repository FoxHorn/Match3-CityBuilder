using System;

public abstract class Model
{
    public event Action OnChanged;

    protected void NotifyObservers()
    {
        OnChanged?.Invoke();
    }
}
