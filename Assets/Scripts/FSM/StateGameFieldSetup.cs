using UnityEngine;

public class StateGameFieldSetup : State
{
    public StateGameFieldSetup(FiniteStateMachine fsm) : base(fsm)
    {
    }

    public override void Enter()
    {
        Debug.Log("Game field setup state [ENTER]");
        //_gameAreaController.ShowArea(() => _fsm.SetState<>());
    }

    public override void Exit()
    {
        Debug.Log("Game field setup state [EXIT]");
    }

    public override void Update()
    {
        Debug.Log("Game field setup state [UPDATE]");
    }
}
