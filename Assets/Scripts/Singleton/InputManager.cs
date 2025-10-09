using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] private EventSystem _eventSystem;

    public void ToggleInput(bool enable)
    {
        _eventSystem.enabled = enable;
    }
}
