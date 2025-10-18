using UnityEngine;

public class StateGameAreaSetup : State
{
    private readonly GameAreaController _gameAreaController;

    public StateGameAreaSetup(FiniteStateMachine fsm, GameAreaController gameAreaController) : base(fsm)
    {
        _gameAreaController = gameAreaController;
    }

    public override void Enter()
    {
        Debug.Log("Game area setup state [ENTER]");
        _gameAreaController.ShowArea(() => Fsm.SetState<StateGameFieldSetup>());
    }

    public override void Exit()
    {
        Debug.Log("Game area setup state [EXIT]");
    }

    public override void Update()
    {
        Debug.Log("Game area setup state [UPDATE]");
    }
}
