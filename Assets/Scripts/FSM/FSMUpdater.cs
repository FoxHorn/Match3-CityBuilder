using UnityEngine;

public class FSMUpdater : MonoBehaviour
{
    private FiniteStateMachine fsm;

    public void Init(FiniteStateMachine fsm)
    {
        this.fsm = fsm;
        enabled = true;
    }

    private void Update()
    {
        fsm?.Update();
    }
}
