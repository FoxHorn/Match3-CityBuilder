public abstract class State
{
    protected readonly FiniteStateMachine Fsm;

    public State(FiniteStateMachine fsm)
    {
        Fsm = fsm;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
