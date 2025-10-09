using UnityEngine;

public abstract class View : MonoBehaviour
{
    protected Model Model { get; private set; }

    public void Init(Model model = null)
    {
        Model = model;
        if (Model != null) Model.OnChanged += UpdateView;
    }

    private void OnDestroy()
    {
        if (Model != null) Model.OnChanged -= UpdateView;
    }

    protected virtual void UpdateView() { }

    public virtual void ResetView() { }
}
